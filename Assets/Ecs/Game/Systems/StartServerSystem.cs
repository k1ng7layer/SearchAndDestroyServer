using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;
using Services.SceneLoading;
using Services.ServerManager;
using StateMachine;
using StateMachine.States.Impl;
using UniRx.Async;

namespace Ecs.Game.Systems
{
    public class StartServerSystem : IInitializeSystem
    {
        private readonly INetworkServerManager _serverManager;
        private readonly IServerStateManager _serverStateManager;
        private readonly ServerStateMachine _serverStateMachine;

        public StartServerSystem(
            INetworkServerManager serverManager,
            IServerStateManager serverStateManager,
            ServerStateMachine serverStateMachine
        )
        {
            _serverManager = serverManager;
            _serverStateManager = serverStateManager;
            _serverStateMachine = serverStateMachine;
        }
        
        public void Initialize()
        {
            Start().Forget();
        }

        private async UniTaskVoid Start()
        {
            //TODO: send message to matchmaking service about server instance was successfully started and receive initial game info:
            //TODO: port number, number of players, etc
            
            
            //_serverManager.StartSever();
            _serverStateMachine.ChangeState<InitializeServerState>();
            
            //TODO: Notify SCS about server opened connection
            
           // await _serverStateManager.ChangeLevelAsync(ELevelName.CLASSIC);
            
            // _serverManager.SendToAll(new LevelLoadingMessage
            // {
            //     LevelName = ELevelName.CLASSIC.ToString()
            // });
            
            //TODO: send message to matchmaking service about server connection was successfully started and server is ready
        }
    }
}