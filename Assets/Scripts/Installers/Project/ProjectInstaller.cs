using Core.LoadingProcessor.Impls;
using HttpTransfer.Impl;
using Services.ClientStateHandler.Impl;
using Services.Network;
using Services.Network.Impl;
using Services.SceneLoading;
using Services.SceneLoading.Impls;
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
            
            BindManagers();
        }

        private void BindManagers()
        {
            SignalBusInstaller.Install(Container);
            Container.BindInterfacesTo<LoadingProcessor>().AsSingle();
            Container.BindInterfacesTo<InitializeServerState>().AsSingle();
            Container.BindInterfacesTo<HttpClientService>().AsSingle();
            Container.BindInterfacesTo<ClientInitializationService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ServerStateMachine>().AsSingle();
            Container.Bind<ISceneLoadingManager>().To<SceneLoadingManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<MirrorNetworkServer>()
                .FromComponentInNewPrefab(_networkServer).AsSingle();
        }
    }
}