using UnityEngine;
using UnityEngine.Serialization;

namespace Services.LevelObjectProvider
{
    public class CommonObjectsHolder : MonoBehaviour
    {
        public Transform ParasiteSpawnTransform;
        public Transform[] GunnersSpawnTransforms;
        public Transform[] NpcSpawnTransforms;
    }
}