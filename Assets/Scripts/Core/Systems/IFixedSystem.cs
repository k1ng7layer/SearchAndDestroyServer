using JCMG.EntitasRedux;

namespace Core.Systems
{
    public interface IFixedSystem : ISystem
    {
        void Fixed();
    }
}