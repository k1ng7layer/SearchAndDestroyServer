using System;
using System.Collections.Generic;
using StateMachine.States;
using UniRx.Async;
using UnityEngine;

namespace StateMachine
{
    public class ServerStateMachine
    {
        private readonly Dictionary<Type, IState> _stateBases = new();
        private IState _currentState;
        
        public ServerStateMachine(List<IState> states)
        {
            foreach (var state in states)
            {
                _stateBases.Add(state.GetType(), state);
                
                state.AttachStateMachine(this);
            }
        }

        public void ChangeState<T>() where T : IState
        {
            var newState = _stateBases[typeof(T)];

            try
            {
                ProcessState(newState).Forget();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw;
            }
        }

        private async UniTask ProcessState(IState state)
        {
            if (_currentState != null) 
            {
                await _currentState.Exit();
            }

            _currentState = state;

            await _currentState.Enter();
        }
    }
}