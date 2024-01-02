using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class InfectedComponent : IComponent
    {
        public Uid.Uid Owner;
    }
}