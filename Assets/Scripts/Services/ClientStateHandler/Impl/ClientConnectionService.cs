using System;
using Models;
using NetworkMessages;
using Services.GameRoles;
using Services.Network;
using Services.PlayerRepository;
using Services.SceneLoading;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace Services.ClientStateHandler.Impl
{
    public class ClientConnectionService : 
        IClientInitializationService, 
        IInitializable, 
        IDisposable
    {
        private readonly INetworkServerManager _serverManager;
        private readonly IGameRoleService _gameRoleService;
        private readonly IPlayerRepository _playerRepository;

        public ClientConnectionService(
            INetworkServerManager serverManager, 
            IGameRoleService gameRoleService,
            IPlayerRepository playerRepository
        )
        {
            _serverManager = serverManager;
            _gameRoleService = gameRoleService;
            _playerRepository = playerRepository;
        }

        public void Initialize()
        {
            _serverManager.ClientConnected += OnClientConnected;
            _gameRoleService.InitializeRoles(1);
        }
        
        public void Dispose()
        {
            //_serverManager.ClientConnected -= OnClientConnected;
        }

        private void OnClientConnected(int connectionId)
        {
            //_playerRepository.Add(new Player(connectionId));
            // _serverManager.SendTo(netId, new LevelLoadingMessage
            // {
            //     LevelName = ELevelName.CLASSIC.ToString()
            // });
        }
    }
}