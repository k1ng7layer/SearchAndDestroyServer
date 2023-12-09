using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class ConnectionIdComponent : IComponent
    {
        [PrimaryEntityIndex]
        public int Value;
    }
}