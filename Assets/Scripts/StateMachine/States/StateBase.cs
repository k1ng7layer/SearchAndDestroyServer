using UniRx.Async;

namespace StateMachine.States
{
    public abstract class StateBase : IState
    {
        public void AttachStateMachine(ServerStateMachine serverStateMachine)
        {
            StateMachine = serverStateMachine;
        }
        
        protected ServerStateMachine StateMachine { get; private set; }
        
        public UniTask Execute()
        {
            return OnExecute();
        }

        public UniTask Enter()
        {
            return OnEnter();
        }

        public UniTask Exit()
        {
            return OnExit();
        }

        protected virtual UniTask OnEnter()
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask OnExecute()
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask OnExit()
        {
            return UniTask.CompletedTask;
        }
    }
    
    public abstract class StateBase<T> : IState
    {
        public void AttachStateMachine(ServerStateMachine serverStateMachine)
        {
            StateMachine = serverStateMachine;
        }
        
        protected ServerStateMachine StateMachine { get; private set; }
        
        public UniTask Execute()
        {
            return OnExecute();
        }

        public UniTask Enter()
        {
            return OnEnter();
        }

        public UniTask Exit()
        {
            return OnExit();
        }

        protected virtual UniTask OnEnter()
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask OnExecute()
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask OnExit()
        {
            return UniTask.CompletedTask;
        }
    }
}