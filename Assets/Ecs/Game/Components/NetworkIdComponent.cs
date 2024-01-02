using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class NetworkIdComponent : IComponent
    {
        [PrimaryEntityIndex]
        public uint Value;
    }
}