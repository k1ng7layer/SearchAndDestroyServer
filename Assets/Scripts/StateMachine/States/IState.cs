using UniRx.Async;

namespace StateMachine.States
{
    public interface IState
    {
        void AttachStateMachine(ServerStateMachine serverStateMachine);
        UniTask Enter();
        UniTask Execute();
        UniTask Exit();
    }
}