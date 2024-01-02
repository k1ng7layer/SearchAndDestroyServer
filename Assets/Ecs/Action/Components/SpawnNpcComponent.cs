using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Components
{
    [Action]
    public class SpawnNpcComponent : IComponent
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}