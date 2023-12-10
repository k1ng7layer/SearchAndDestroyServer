using System;
using Db.Prefabs;
using Ecs.Views.Linkable;
using UnityEngine;
using Zenject;

namespace Services.Spawn.Impl
{
    public class DiSpawnService : ISpawnService
    {
        private readonly DiContainer _diContainer;
        private readonly IPrefabsBase _prefabBase;

        public DiSpawnService(DiContainer diContainer, IPrefabsBase prefabBase)
        {
            _diContainer = diContainer;
            _prefabBase = prefabBase;
        }
        
        public ILinkableView Spawn(GameEntity entity)
        {
            var position = entity.HasPosition ? entity.Position.Value : Vector3.zero;
            var rotation = entity.HasRotation ? entity.Rotation.Value : Quaternion.identity;
            if (entity.HasPrefab)
            {
                var prefabName = entity.Prefab.Name;
                var prefab = _prefabBase.Get(prefabName);
                var obj = _diContainer.InstantiatePrefab(prefab.gameObject, position, rotation, null);
                //entity.AddTransform(obj.transform);
                if(obj.TryGetComponent<ILinkableView>(out var view))
                {
                    return view;
                }

                throw new Exception($"[{nameof(DiSpawnService)}] cant instantiate entity w/o linkable view");
            }
            
            throw new Exception($"[{nameof(DiSpawnService)}] cant instantiate entity w/o prefab");
        }
    }
}