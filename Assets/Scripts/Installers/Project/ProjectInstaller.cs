using Core.LoadingProcessor.Impls;
using HttpTransfer.Impl;
using Services.ClientStateHandler.Impl;
using Services.Network;
using Services.Network.Impl;
using Services.PlayerRepository.Impl;
using Services.PlayerService.Impl;
using Services.SceneLoading;
using Services.SceneLoading.Impls;
using Services.TimeProvider.Impl;
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
        }

        private void BindManagers()
        {
         
            Container.BindInterfacesTo<LoadingProcessor>().AsSingle();
            Container.BindInterfacesTo<InitializeServerState>().AsSingle();
            Container.BindInterfacesTo<HttpClientService>().AsSingle();
            Container.BindInterfacesTo<ClientInitializationService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ServerStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerStatusService>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerRepository>().AsSingle();
            Container.Bind<ISceneLoadingManager>().To<SceneLoadingManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<MirrorNetworkServer>()
                .FromComponentInNewPrefab(_networkServer).AsSingle();
            Container.BindInterfacesAndSelfTo<TimeProvider>().AsSingle();
        }
    }
}