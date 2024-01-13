using ActionSequence;
using Core.LoadingProcessor.Impls;
using HttpTransfer.Impl;
using Services.ClientLoading;
using Services.ClientStateHandler.Impl;
using Services.GameRoles.Impl;
using Services.Network;
using Services.Network.Impl;
using Services.PlayerInput.impl;
using Services.PlayerMessageService.Impl;
using Services.PlayerRepository.Impl;
using Services.PlayerStateService;
using Services.SceneLoading;
using Services.SceneLoading.Impls;
using Services.ServerManager;
using Services.ServerManager.Impl;
using Services.TimeProvider.Impl;
using Signals;
using StateMachine;
using StateMachine.States.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private MirrorNetworkServer _networkServer;
        
        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;
            SignalBusInstaller.Install(Container);
            
            BindManagers();
            BindStateMachine();
            BindSignals();
        }

        private void BindManagers()
        {
         
            Container.BindInterfacesTo<LoadingProcessor>().AsSingle();
          
            Container.BindInterfacesTo<HttpClientService>().AsSingle();
            Container.BindInterfacesTo<ClientConnectionService>().AsSingle();
          
            Container.BindInterfacesAndSelfTo<PlayerMessageService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<RandomGameRoleService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoadingManager>().AsSingle();
            Container.Bind<IServerStateManager>().To<ServerStateManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<MirrorNetworkServer>()
                .FromComponentInNewPrefab(_networkServer).AsSingle();
            Container.BindInterfacesAndSelfTo<TimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<AsyncActionSequenceService>().AsSingle();
            Container.BindInterfacesAndSelfTo<NetworkInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerStateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ClientLoadingService>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<ServerStateMachine>().AsSingle();
            
            Container.BindInterfacesTo<InitializeServerState>().AsSingle();
            //Container.BindInterfacesTo<PendingForConnectionsState>().AsSingle();
            Container.BindInterfacesTo<PendingForConnectionsState2>().AsSingle();
            Container.BindInterfacesTo<BeginGameLevelState>().AsSingle();
            Container.BindInterfacesTo<NextLevelLoadingState>().AsSingle();
            Container.BindInterfacesTo<GameLevelLoopState>().AsSingle();
            Container.BindInterfacesTo<InitialClientLoadingState>().AsSingle();
        }

        private void BindSignals()
        {
            Container.DeclareSignal<SignalLevelStart>();
            Container.DeclareSignal<SignalLevelStop>();
        }
    }
}