using Models;
using NetworkMessages;
using Services.ClientLoading;
using Services.Network;
using Services.PlayerRepository;
using Services.SceneLoading;
using UniRx.Async;

namespace StateMachine.States.Impl
{
    public class PendingForConnectionsState2 : StateBase
    {
        private const int MaxPlayers = 2;
        
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPlayerRepository _playerRepository;
        private readonly ClientLoadingService _clientLoadingService;
        private UniTaskCompletionSource _clientConnectedTcs;

        public PendingForConnectionsState2(
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
            _clientConnectedTcs?.TrySetCanceled();
            _clientConnectedTcs = new UniTaskCompletionSource();
            _networkServerManager.ClientConnected += OnClientConnected;
            
            await _clientConnectedTcs.Task;
            
            StateMachine.ChangeState<InitialClientLoadingState>();
        }

        protected override UniTask OnExit()
        {
            _networkServerManager.ClientConnected -= OnClientConnected;
            _clientConnectedTcs?.TrySetCanceled();
            
            return UniTask.CompletedTask;
        }

        private void OnClientConnected(int connId)
        {
            _playerRepository.Add(new Player(connId));
            
            // _networkServerManager.SendTo(connId, new LevelLoadingMessage
            // {
            //     LevelName = ELevelName.CLASSIC.ToString()
            // });

            if (_playerRepository.Players.Count == MaxPlayers)
                _clientConnectedTcs.TrySetResult();
        }
    }
}