using System;
using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using Mirror;
using Models;
using NetworkMessages;
using Services.Network;
using Services.PlayerRepository;
using UnityEngine;
using Zenject;

namespace Services.PlayerService.Impl
{
    public class PlayerStatusService : IPlayerStatusService, 
        IInitializable, 
        IDisposable
    {
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPlayerRepository _playerRepository;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _players;

        public PlayerStatusService(
            INetworkServerManager networkServerManager, 
            IPlayerRepository playerRepository
        )
        {
            _networkServerManager = networkServerManager;
            _playerRepository = playerRepository;
            // _game = game;

            //_players = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player).NoneOf(GameMatcher.Destroyed));
        }
        
        public event Action<Player> PlayerReady;
        public event Action<Player> PlayerLoaded;

        public void Initialize()
        {
            _networkServerManager.RegisterMessageHandler<PlayerLoadedMessage>(OnPlayerLoadedMessage);
            _networkServerManager.RegisterMessageHandler<PlayerSpawnedMessage>(OnPlayerSpawnedMessage);
        }

        public void Dispose()
        {
            _networkServerManager.UnRegisterMessageHandler<PlayerLoadedMessage>();
            _networkServerManager.UnRegisterMessageHandler<SpawnPlayerMessage>();
        }

        private void OnPlayerLoadedMessage(
            NetworkConnectionToClient conn, 
            PlayerLoadedMessage _, 
            int id)
        {
            var player = new Player(conn.connectionId)
            {
                Loaded = true
            };

            if (!_playerRepository.Players.ContainsKey(conn.connectionId))
                _playerRepository.Add(player);
            
            PlayerLoaded?.Invoke(player);

            NetworkServer.SetClientReady(conn);
            Debug.Log($"OnPlayerLoadedMessage, ready: {conn.isReady}");
            NetworkServer.SpawnObjects();
        }
        
        private void OnPlayerSpawnedMessage(
            NetworkConnectionToClient conn, 
            PlayerSpawnedMessage _, 
            int id)
        {
            NetworkServer.SpawnObjects();
        }

        private void SpawnObjectsForPlayer()
        {
            // var players = _players.GetEntities();
            //
            // foreach (var player in players)
            // {
            //     var view = (NetworkObjectView)player.Link.View;
            //     
            //     NetworkServer.Spawn(view, );
            // }
        }
    }
}