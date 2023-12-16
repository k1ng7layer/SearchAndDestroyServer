using Ecs.Game.Systems;
using Services.PlayerInput.impl;
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
            Container.BindInterfacesAndSelfTo<WaitPlayersLoadedSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnPlayerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartGameSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartCountdownSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveDirectionSystem>().AsSingle();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<NetworkInputService>().AsSingle();
        }
    }
}