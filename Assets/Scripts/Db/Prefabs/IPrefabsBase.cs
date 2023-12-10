using Db.Prefabs.Impl;
using UnityEngine;

namespace Db.Prefabs
{
    public interface IPrefabsBase
    {
        NetworkPrefab Get(string prefabName);
    }
}