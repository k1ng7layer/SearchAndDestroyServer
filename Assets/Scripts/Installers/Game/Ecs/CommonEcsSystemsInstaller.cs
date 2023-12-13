using Ecs.Game.Systems;
using Services.PlayerService.Impl;
using Zenject;
using SpawnPlayerSystem = Ecs.Action.Systems.SpawnPlayerSystem;

namespace Installers.Game.Ecs
{
    public class CommonEcsSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InitializeGameSystem>().AsSingle();
            //Container.BindInterfacesAndSelfTo<SpawnPlayerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartGameSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnPlayerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<WaitPlayersLoadedSystem>().AsSingle();
        }
    }
}