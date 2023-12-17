using Db.Prefabs;
using Db.Prefabs.Impl;
using Settings.Common;
using Settings.Common.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SoPrefabsBase _prefabsBase;
        [SerializeField] private CommonGameSettings _commonGameSettings;

        public override void InstallBindings()
        {
            Container.Bind<IPrefabsBase>().To<SoPrefabsBase>().FromInstance(_prefabsBase).AsSingle();
            Container.Bind<ICommonGameSettings>().To<CommonGameSettings>().FromInstance(_commonGameSettings).AsSingle();
        }
    }
}