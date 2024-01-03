using UnityEngine;

namespace Settings.Player.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(PlayerSettings), fileName = nameof(PlayerSettings))]
    public class PlayerSettings : ScriptableObject, 
        IPlayerSettings
    {
        [SerializeField] private float _maxDetachedTime = 10;

        public float MaxDetachedTime => _maxDetachedTime;
    }
}