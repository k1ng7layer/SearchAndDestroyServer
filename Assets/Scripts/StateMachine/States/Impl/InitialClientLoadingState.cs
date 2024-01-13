using Services.ClientLoading;
using Services.SceneLoading;
using Signals;
using UniRx.Async;
using Utils;
using Zenject;

namespace StateMachine.States.Impl
{
    public class InitialClientLoadingState : StateBase
    {
        private readonly SignalBus _signalBus;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly ClientLoadingService _clientLoadingService;

        public InitialClientLoadingState(
            SignalBus signalBus,
            ISceneLoadingManager sceneLoadingManager,
            ClientLoadingService clientLoadingService)
        {
            _signalBus = signalBus;
            _sceneLoadingManager = sceneLoadingManager;
            _clientLoadingService = clientLoadingService;
        }

        protected override async UniTask OnEnter()
        {
            _signalBus.Fire<SignalLevelStop>();
            
            var serverLoading = _sceneLoadingManager.LoadGameLevelAsync(ELevelName.CLASSIC);

            var clientsLoading =  _clientLoadingService.LoadLevelOnClientsAsync(ELevelName.CLASSIC);

            await UniTask.WhenAll(serverLoading, clientsLoading);
            
            StateMachine.ChangeState<BeginGameLevelState>();
        }
    }
}