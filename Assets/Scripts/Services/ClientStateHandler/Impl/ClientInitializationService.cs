using System;
using NetworkMessages;
using Services.Network;
using Services.SceneLoading;
using UniRx.Async;
using UnityEngine;
using Zenject;

namespace Services.ClientStateHandler.Impl
{
    public class ClientInitializationService : IClientInitializationService, IInitializable, IDisposable
    {
        private readonly INetworkServerManager _serverManager;

        public ClientInitializationService(INetworkServerManager serverManager)
        {
            _serverManager = serverManager;
        }

        public void Initialize()
        {
            _serverManager.ClientConnected += OnClientConnected;
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