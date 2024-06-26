﻿using Db.Prefabs;
using Db.Prefabs.Impl;
using Settings.Common;
using Settings.Common.Impl;
using Settings.Npc;
using Settings.Npc.Impl;
using Settings.Player;
using Settings.Player.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SoPrefabsBase _prefabsBase;
        [SerializeField] private CommonGameSettings _commonGameSettings;
        [SerializeField] private NpcSettings _npcSettings;
        [SerializeField] private PlayerSettings _playerSettings;

        public override void InstallBindings()
        {
            Container.Bind<IPrefabsBase>().To<SoPrefabsBase>().FromInstance(_prefabsBase).AsSingle();
            Container.Bind<ICommonGameSettings>().To<CommonGameSettings>().FromInstance(_commonGameSettings).AsSingle();
            Container.Bind<INpcSettings>().To<NpcSettings>().FromInstance(_npcSettings).AsSingle();
            Container.Bind<IPlayerSettings>().To<PlayerSettings>().FromInstance(_playerSettings).AsSingle();
        }
    }
}