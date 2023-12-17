using Core.Systems;
using JCMG.EntitasRedux;

namespace Services.TimeProvider.Impl
{
    public class TimeProvider : ITimeProvider, 
        IUpdateSystem,
        IFixedSystem
    {
        public float DeltaTime { get; private set; }
        
        public float FixedDeltaTime { get; private set; }
        
        public void Update()
        {
            DeltaTime = UnityEngine.Time.deltaTime;
        }

        public void Fixed()
        {
            FixedDeltaTime = UnityEngine.Time.fixedDeltaTime;
        }
    }
}