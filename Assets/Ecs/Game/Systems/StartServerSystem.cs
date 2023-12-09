using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;
using Services.SceneLoading;
using StateMachine;
using UniRx.Async;

namespace Ecs.Game.Systems
{
    public class StartServerSystem : IInitializeSystem
    {
        private readonly INetworkServerManager _serverManager;
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly ServerStateMachine _serverStateMachine;

        public StartServerSystem(
            INetworkServerManager serverManager, 
            ISceneLoadingManager sceneLoadingManager,
            ServerStateMachine serverStateMachine
        )
        {
            _serverManager = serverManager;
            _sceneLoadingManager = sceneLoadingManager;
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
            
            
            _serverManager.StartSever();
            
            //TODO: Notify SCS about server opened connection
            
            _sceneLoadingManager.LoadGameLevel(ELevelName.CLASSIC);
            
            // _serverManager.SendToAll(new LevelLoadingMessage
            // {
            //     LevelName = ELevelName.CLASSIC.ToString()
            // });
            
            //TODO: send message to matchmaking service about server connection was successfully started and server is ready
        }
    }
}