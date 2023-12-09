using Core.LoadingProcessor.Impls;
using Services.Network;
using Services.Network.Impl;
using Services.SceneLoading;
using Services.SceneLoading.Impls;
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
            Container.Bind<ISceneLoadingManager>().To<SceneLoadingManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<MirrorNetworkServer>()
                .FromComponentInNewPrefab(_networkServer).AsSingle();
        }
    }
}