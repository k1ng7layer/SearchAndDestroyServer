using Ecs.Game.Systems;
using Zenject;

namespace Installers.Game.Ecs
{
    public class CommonEcsSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WaitForClientsSystem>().AsSingle();
        }
    }
}