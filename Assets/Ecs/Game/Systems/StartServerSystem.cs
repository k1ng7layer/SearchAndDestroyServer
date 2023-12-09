using JCMG.EntitasRedux;
using Services.Network;
using UniRx.Async;

namespace Ecs.Game.Systems
{
    public class StartServerSystem : IInitializeSystem
    {
        private readonly INetworkServerManager _serverManager;

        public StartServerSystem(INetworkServerManager serverManager)
        {
            _serverManager = serverManager;
        }
        
        public void Initialize()
        {
            _serverManager.StartSever();
        }

        private async UniTaskVoid Start()
        {
            _serverManager.StartSever();
        }
    }
}