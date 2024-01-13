using Services.ClientLoading;
using UniRx.Async;

namespace StateMachine.States.Impl
{
    public class WaitClientLoadingState : StateBase
    {
        private readonly ClientLoadingService _clientLoadingService;

        public WaitClientLoadingState(ClientLoadingService clientLoadingService)
        {
            _clientLoadingService = clientLoadingService;
        }
        
        protected override async UniTask OnEnter()
        {
            //_clientLoadingService.WaitClientLoadedAsync()
        }
    }
}