using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
    [Game]
    public class InfectedComponent : IComponent
    {
        public Uid.Uid Owner;
    }
}