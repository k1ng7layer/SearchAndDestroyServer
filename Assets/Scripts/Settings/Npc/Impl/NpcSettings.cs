using UnityEngine;
using UnityEngine.Serialization;

namespace Settings.Npc.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(NpcSettings), fileName = nameof(NpcSettings))]
    public class NpcSettings : ScriptableObject, INpcSettings
    {
        [SerializeField] private float _destinationChooseMinRadius = 5f;
        [SerializeField] private float _destinationChooseMaxRadius = 10f;
        [SerializeField] private float _destinationCheckDistance = 1.1f;

        public float DestinationChooseMinRadius => _destinationChooseMinRadius;

        public float DestinationChooseMaxRadius => _destinationChooseMaxRadius;
        public float DestinationCheckDistance => _destinationCheckDistance;
    }
}