namespace StateMachine.States
{
    public abstract class StateBase
    {
        public void Execute()
        {
            
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }

        protected virtual void OnEnter()
        { }

        protected virtual void OnExecute()
        { }
    }
}