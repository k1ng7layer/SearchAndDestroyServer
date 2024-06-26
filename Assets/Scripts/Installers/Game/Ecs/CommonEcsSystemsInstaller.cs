﻿using Ecs.Action.Systems;
using Ecs.Game.Systems;
using Services.PlayerInput.impl;
using Zenject;
using SpawnPlayerSystem = Ecs.Action.Systems.SpawnPlayerSystem;

namespace Installers.Game.Ecs
{
    public class CommonEcsSystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InitializeGameLevelSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SyncGameStateSystem>().AsSingle();
            //Container.BindInterfacesAndSelfTo<WaitPlayersLoadedSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnPlayerSystem>().AsSingle();
            //Container.BindInterfacesAndSelfTo<WaitPlayerSpawnedSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartPreparingCountdownSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveDirectionSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInputRotationSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CountdownTickSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SyncGameCountdownSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnNpcSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChooseDestinationSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CheckDestinationSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InfectNpcSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<AttachPlayerToNpcSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerStateTimerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<DetachPlayerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MentalOverloadSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StopGameRoundSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartGameRoundSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ReadPlayerMovementSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SendRolesWeirdSystem>().AsSingle();
            
            BindServices();
        }

        private void BindServices()
        {
            
        }
    }
}