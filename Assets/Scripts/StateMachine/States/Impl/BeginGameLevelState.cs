using Mirror;
using NetworkMessages;
using Services.GameRoles;
using Services.Network;
using Services.PlayerRepository;
using Signals;
using UniRx.Async;
using Zenject;

namespace StateMachine.States.Impl
{
    public class BeginGameLevelState : StateBase
    {
        private readonly IGameRoleService _gameRoleService;
        private readonly SignalBus _signalBus;
        private readonly IPlayerRepository _playerRepository;
        private readonly INetworkServerManager _networkServerManager;
        private UniTaskCompletionSource _roleAttachTcs;

        public BeginGameLevelState(
            IGameRoleService gameRoleService, 
            SignalBus signalBus,
            IPlayerRepository playerRepository,
            INetworkServerManager networkServerManager
        )
        {
            _gameRoleService = gameRoleService;
            _signalBus = signalBus;
            _playerRepository = playerRepository;
            _networkServerManager = networkServerManager;
        }

        protected override async UniTask OnEnter()
        {
            _roleAttachTcs?.TrySetCanceled();
            
            _gameRoleService.InitializeSession(1);
            
            _networkServerManager.RegisterMessageHandler<PlayerReadyMessage>(OnPlayerReady);
            
            foreach (var kvp in _playerRepository.Players)
            {
                _gameRoleService.TryGetGameRole(out var role);
                
                _networkServerManager.SendTo(kvp.Value.ConnectionId, new RoleAssignMessage
                {
                    Role = (byte)role
                });
            }
            
            _roleAttachTcs = new UniTaskCompletionSource();

            await _roleAttachTcs.Task;
            
            _signalBus.Fire<SignalLevelStart>();
            
            StateMachine.ChangeState<GameLevelLoopState>();
        }

        protected override UniTask OnExit()
        {
            _networkServerManager.UnRegisterMessageHandler<PlayerReadyMessage>();

            return UniTask.CompletedTask;
        }

        private void OnPlayerReady(
            NetworkConnectionToClient conn, 
            PlayerReadyMessage msg, 
            int id)
        {
            var hasPlayer = _playerRepository.TryGet(conn.connectionId, out var player);
            
            if (!hasPlayer) return;

            player.Ready = true;

            foreach (var kvp in _playerRepository.Players)
            {
                if (!kvp.Value.Ready)
                    return;
            }

            _roleAttachTcs.TrySetResult();
        }
    }
}