using System.Collections.Generic;
using StateMachine.States;

namespace StateMachine
{
    public class ServerStateMachine
    {
        private readonly List<IState> _stateBases = new();
        
        public ServerStateMachine(List<IState> stateBases)
        {
            _stateBases = stateBases;
        }

        public void ChangeState()
        {
            _stateBases[0].Enter();
        }
    }
}