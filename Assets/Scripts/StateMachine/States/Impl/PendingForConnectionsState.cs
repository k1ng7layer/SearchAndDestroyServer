using System;
using Mirror;
using Models;
using NetworkMessages;
using Services.ClientLoading;
using Services.Network;
using Services.PlayerRepository;
using Services.SceneLoading;
using UniRx.Async;

namespace StateMachine.States.Impl
{
    public class PendingForConnectionsState : StateBase, IDisposable
    {
        private const int MaxPlayers = 1;
        
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPlayerRepository _playerRepository;
        private readonly ClientLoadingService _clientLoadingService;
        private UniTaskCompletionSource _clientsConnectedTcs;
        private UniTaskCompletionSource _clientsLoadedTcs;

        public PendingForConnectionsState(
            INetworkServerManager networkServerManager, 
            IPlayerRepository playerRepository,
            ClientLoadingService clientLoadingService
        )
        {
            _networkServerManager = networkServerManager;
            _playerRepository = playerRepository;
            _clientLoadingService = clientLoadingService;
        }
        
        protected override async UniTask OnEnter()
        {
            _clientsLoadedTcs?.TrySetCanceled();
            _clientsLoadedTcs = new UniTaskCompletionSource();
            
            _networkServerManager.ClientConnected += OnClientConnected;
            _clientLoadingService.ClientLoaded += OnPlayerLoaded;
            
            await _clientsLoadedTcs.Task;
            
            StateMachine.ChangeState<BeginGameLevelState>();
        }

        protected override UniTask OnExit()
        {
            _networkServerManager.ClientConnected -= OnClientConnected;
            _clientLoadingService.ClientLoaded -= OnPlayerLoaded;
            
            return UniTask.CompletedTask;
        }

        private void OnClientConnected(int connectionId)
        {
            _playerRepository.Add(new Player(connectionId));
            
            _networkServerManager.SendTo(connectionId, new LevelLoadingMessage
            {
                LevelName = ELevelName.CLASSIC.ToString()
            });
        }

        private void OnPlayerLoaded(int connectionId)
        {
            if (!_playerRepository.TryGet(connectionId, out var player)) return;

            player.Loaded = true;
            
            foreach (var kvp in _playerRepository.Players)
            {
                if (!kvp.Value.Loaded)
                    return;
            }

            _clientsLoadedTcs.TrySetResult();
        }

        public void Dispose()
        {
            _clientsLoadedTcs.TrySetCanceled();
        }
    }
}