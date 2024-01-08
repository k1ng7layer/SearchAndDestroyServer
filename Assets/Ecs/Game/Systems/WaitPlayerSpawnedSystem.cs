using System;
using System.Collections.Generic;
using JCMG.EntitasRedux;
using Mirror;
using Models;
using NetworkMessages;
using Services.Network;
using Services.PlayerMessageService;
using Services.PlayerRepository;
using Utils;

namespace Ecs.Game.Systems
{
    public class WaitPlayerSpawnedSystem : IInitializeSystem, IDisposable
    {
        private const int MaxPlayers = 1;
        
        private readonly GameContext _game;
        private readonly INetworkServerManager _serverManager;
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerMessageService _playerMessageService;
        private readonly IGroup<GameEntity> _spawnedPlayerGroup;

        public WaitPlayerSpawnedSystem(
            GameContext game, 
            INetworkServerManager serverManager,
            IPlayerRepository playerRepository,
            IPlayerMessageService playerMessageService)
        {
            _game = game;
            _serverManager = serverManager;
            _playerRepository = playerRepository;
            _playerMessageService = playerMessageService;

            _spawnedPlayerGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
        }
        
        public void Initialize()
        {
            _playerMessageService.PlayerReady += OnPlayerReady; 
        }
        
        public void Dispose()
        {
            _playerMessageService.PlayerReady -= OnPlayerReady;
        }

        private void OnPlayerReady(Player player)
        {
            if (AllSpawned() && AllReady())
                _game.ReplaceGameState(EGameState.Countdown);
        }

        private bool AllSpawned()
        {
            int temp = 0;

            foreach (var spawned in _spawnedPlayerGroup)
            {
                if (spawned.IsInstantiate)
                    temp++;
            }

            return temp == MaxPlayers;
        }

        private bool AllReady()
        {
            foreach (var kvp in _playerRepository.Players)
            {
                if (!kvp.Value.Ready)
                    return false;
            }

            return true;
        }
    }
}