using System;
using NetworkMessages;
using Services.GameRoles;
using Services.Network;
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

        public ClientConnectionService(
            INetworkServerManager serverManager, 
            IGameRoleService gameRoleService
        )
        {
            _serverManager = serverManager;
            _gameRoleService = gameRoleService;
        }

        public void Initialize()
        {
            _serverManager.ClientConnected += OnClientConnected;
            _gameRoleService.InitializeSession(1);
        }
        
        public void Dispose()
        {
            _serverManager.ClientConnected -= OnClientConnected;
        }

        private void OnClientConnected(int netId)
        {
            _serverManager.SendTo(netId, new LevelLoadingMessage
            {
                LevelName = ELevelName.CLASSIC.ToString()
            });
        }
    }
}