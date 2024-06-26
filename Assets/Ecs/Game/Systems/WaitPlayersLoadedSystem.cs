﻿using System;
using JCMG.EntitasRedux;
using Models;
using NetworkMessages;
using Services.GameRoles;
using Services.Network;
using Services.PlayerMessageService;
using Services.PlayerRepository;
using Services.ServerManager;

namespace Ecs.Game.Systems
{
    public class WaitPlayersLoadedSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly IPlayerMessageService _playerMessageService;
        private readonly IPlayerRepository _playerRepository;
        private readonly INetworkServerManager _serverManager;
        private readonly IGameRoleService _gameRoleService;
        private readonly IServerStateManager _serverStateManager;
        private readonly ActionContext _action;

        public WaitPlayersLoadedSystem(
            IPlayerMessageService playerMessageService, 
            IPlayerRepository playerRepository,
            INetworkServerManager serverManager,
            IGameRoleService gameRoleService,
            IServerStateManager serverStateManager,
            ActionContext action
        )
        {
            _playerMessageService = playerMessageService;
            _playerRepository = playerRepository;
            _action = action;
            _serverManager = serverManager;
            _gameRoleService = gameRoleService;
            _serverStateManager = serverStateManager;
        }
        
        public void Initialize()
        {
            //TODO: start timer
            _playerMessageService.PlayerLoaded += OnPlayerLoaded;
            _serverStateManager.ServerReady += SpawnPlayers;
        }
        
        public void Dispose()
        {
            _playerMessageService.PlayerLoaded -= OnPlayerLoaded;
            _serverStateManager.ServerReady -= SpawnPlayers;
        }

        private void OnPlayerLoaded(Player player)
        {
            _gameRoleService.TryGetGameRole(out var role);
            
            _serverManager.SendTo(player.ConnectionId, new RoleInitialAssignMessage
            {
                Role = (byte)role
            });
            
            if (!AllLoaded() || !_serverStateManager.Ready) return;

            SpawnPlayers();
        }

        private void SpawnPlayers()
        {
            if (!_serverStateManager.Ready)
                return;
            
            foreach (var playerKvp in _playerRepository.Players)
            {
                _action.CreateEntity().AddSpawnPlayer(playerKvp.Value.ConnectionId);
            }
        }

        private bool AllLoaded()
        {
            // foreach (var playerKvp in _playerRepository.Players)
            // {
            //     if (!playerKvp.Value.Loaded)
            //         return false;
            // }

            // return true;

            return _playerRepository.Players.Count == 1;
        }
    }
}