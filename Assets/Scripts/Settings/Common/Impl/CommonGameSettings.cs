using UnityEngine;

namespace Settings.Common.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(CommonGameSettings), fileName = nameof(CommonGameSettings))]
    public class CommonGameSettings : ScriptableObject, ICommonGameSettings
    {
        [SerializeField] private float _preparingTime = 10f;

        public float PreparingTime => _preparingTime;
    }
}