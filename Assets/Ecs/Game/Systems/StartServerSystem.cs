using JCMG.EntitasRedux;
using Services.Network;
using Services.SceneLoading;
using UniRx.Async;

namespace Ecs.Game.Systems
{
    public class StartServerSystem : IInitializeSystem
    {
        private readonly INetworkServerManager _serverManager;
        private readonly ISceneLoadingManager _sceneLoadingManager;

        public StartServerSystem(
            INetworkServerManager serverManager, 
            ISceneLoadingManager sceneLoadingManager
        )
        {
            _serverManager = serverManager;
            _sceneLoadingManager = sceneLoadingManager;
        }
        
        public void Initialize()
        {
            Start().Forget();
        }

        private async UniTaskVoid Start()
        {
            //TODO: send message to matchmaking service about server instance was successfully started and receive initial game info:
            //TODO: port number, number of players, etc
            
            _sceneLoadingManager.LoadGameLevel(ELevelName.CLASSIC);
            _serverManager.StartSever();
            
            //TODO: send message to matchmaking service about server connection was successfully started and server is ready
        }
    }
}