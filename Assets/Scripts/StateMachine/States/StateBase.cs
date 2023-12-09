namespace StateMachine.States
{
    public abstract class StateBase : IState
    {
        public void Execute()
        {
            OnExecute();
        }

        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }

        protected virtual void OnEnter()
        { }

        protected virtual void OnExecute()
        { }
        
        protected virtual void OnExit()
        { }
    }
}