using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class ConnectionIdComponent : IComponent
    {
        [EntityIndex]
        public int Value;
    }
}