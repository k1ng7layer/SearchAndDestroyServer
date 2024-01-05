using Services.SceneLoading;
using Services.ServerManager;
using Zenject;

namespace Services.Splash
{
    public class SplashManager : IInitializable
    {
        private readonly IServerStateManager _serverStateManager;

        public SplashManager(IServerStateManager serverStateManager)
        {
            _serverStateManager = serverStateManager;
        }
        
        public void Initialize()
        {
            _serverStateManager.InitializeServer();
        }
    }
}