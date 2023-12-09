using Ecs.Game.Systems;
using Zenject;

namespace Installers.Game.Ecs
{
    public class EcsInitSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StartServerSystem>().AsSingle();
        }
    }
}