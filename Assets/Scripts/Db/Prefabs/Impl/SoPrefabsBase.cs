using System;
using Mirror;
using UnityEngine;
using Utils;

namespace Db.Prefabs.Impl
{
    [CreateAssetMenu(menuName = "Settings/PrefabsBase", fileName = "PrefabsBase")]
    public class SoPrefabsBase : ScriptableObject, IPrefabsBase, IPrefabInitializer
    {
        [KeyValue(nameof(NetworkPrefab.AssetId))] 
        [SerializeField] private NetworkPrefab[] prefabs;

        public NetworkPrefab Get(string prefabName)
        {
            for (var i = 0; i < prefabs.Length; i++)
            {
                var prefab = prefabs[i];
                if (prefab.Name == prefabName)
                    return prefab;
            }

            throw new Exception($"[PrefabsBase] Can't find prefab with name: {prefabName}");
        }

        public NetworkPrefab Get(uint assetId)
        {
            for (var i = 0; i < prefabs.Length; i++)
            {
                var prefab = prefabs[i];
                if (prefab.AssetId == assetId)
                    return prefab;
            }

            throw new Exception($"[PrefabsBase] Can't find prefab with asset id: {assetId}");
        }

        [Serializable]
        public class Prefab
        {
            public string name;
            public GameObject gameObject;
        }
        
        public void Initialize()
        {
            foreach (var prefab in prefabs)
            {
                var identity = prefab.gameObject.GetComponent<NetworkIdentity>();

                prefab.AssetId = identity.assetId;
            }
        }
    }
    
    [Serializable]
    public class NetworkPrefab
    {
        public uint AssetId;
        public string Name;
        public GameObject gameObject;
    }
}