using NetworkMessages;
using Services.ClientLoading;
using Services.PlayerStateService;
using Services.SceneLoading;
using Signals;
using UniRx.Async;
using Utils;
using Zenject;

namespace StateMachine.States.Impl
{
    public class NextLevelLoadingState : StateBase
    {
        private readonly SignalBus _signalBus;
        private readonly PlayerStateService _playerStateService;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly ClientLoadingService _clientLoadingService;

        public NextLevelLoadingState(
            SignalBus signalBus, 
            PlayerStateService playerStateService,
            ISceneLoadingManager sceneLoadingManager,
            ClientLoadingService clientLoadingService)
        {
            _signalBus = signalBus;
            _playerStateService = playerStateService;
            _sceneLoadingManager = sceneLoadingManager;
            _clientLoadingService = clientLoadingService;
        }

        protected override async UniTask OnEnter()
        {
            _signalBus.Fire<SignalLevelStop>();
            
            await _playerStateService.ChangeClientsStateAsync(EGameState.Default);
            
            var serverLoading = _sceneLoadingManager.LoadGameLevelAsync(ELevelName.CLASSIC);

            var clientsLoading =  _clientLoadingService.LoadLevelOnClientsAsync(ELevelName.CLASSIC);

            await UniTask.WhenAll(serverLoading, clientsLoading);
            
            StateMachine.ChangeState<BeginGameLevelState>();
        }
    }
}