using Services.LevelObjectProvider;
using Services.LevelObjectProvider.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private CommonObjectsHolder _commonObjectsHolder;

        public override void InstallBindings()
        {
            var holder = new LevelObjectsHolder(_commonObjectsHolder);

            Container.Bind<ILevelObjectsHolder>().To<LevelObjectsHolder>().FromInstance(holder).AsSingle();
        }
    }
}