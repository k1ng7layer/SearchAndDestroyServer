using System;
using Mirror;
using NetworkMessages;
using Services.ClientLoading;
using Services.Network;
using Services.PlayerRepository;
using Services.SceneLoading;
using UniRx;
using UniRx.Async;
using UnityEngine;
using Utils;

namespace Services.ServerManager.Impl
{
    public class ServerStateManager : IServerStateManager, IDisposable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPlayerRepository _playerRepository;
        private readonly PlayerStateService.PlayerStateService _playerStateService;
        private readonly ClientLoadingService _clientLoadingService;

        private EServerState _serverState;

        public ServerStateManager(
            ISceneLoadingManager sceneLoadingManager, 
            INetworkServerManager networkServerManager,
            IPlayerRepository playerRepository,
            PlayerStateService.PlayerStateService playerStateService,
            ClientLoadingService clientLoadingService
        )
        {
            _sceneLoadingManager = sceneLoadingManager;
            _networkServerManager = networkServerManager;
            _playerRepository = playerRepository;
            _playerStateService = playerStateService;
            _clientLoadingService = clientLoadingService;
        }

        public bool Ready { get; private set; }

        public event Action GameStopped;
        public event Action ServerReady;

        public void InitializeServer()
        {
            _sceneLoadingManager.Loaded += OnLoaded;
            //_sceneLoadingManager.LoadGameFromSplash();
            _serverState = EServerState.PendingForClients;
        }
        
        public void Dispose()
        {
            _sceneLoadingManager.Loaded -= OnLoaded;
        }

        public async UniTask ChangeLevelAsync(ELevelName levelName)
        {
            Ready = false;

            foreach (var kvp in _playerRepository.Players)
            {
                kvp.Value.Ready = false;
            }
            
            GameStopped?.Invoke();
            
            await UniTask.Delay(2000);
            
            Debug.Log($"TEST EGameState.Default");

            await _playerStateService.ChangeClientsStateAsync(EGameState.Default);
            
            await UniTask.Delay(500);
            
            var serverLoading = _sceneLoadingManager.LoadGameLevelAsync(levelName);

            var clientsLoading =  _clientLoadingService.LoadLevelOnClientsAsync(levelName);

            await UniTask.WhenAll(serverLoading, clientsLoading);
            
            Ready = true;
            
            ServerReady?.Invoke();
        }

        public void SetServerState(EServerState state)
        {
            
        }

        public void Pause(bool value)
        {
            
        }

        public void ShutDownServer()
        {
            
        }

        private void OnLoaded()
        {
            Ready = true;
                
           // ServerReady?.Invoke();
        }
    }
}