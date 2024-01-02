using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
    [Action]
    public class DetachPlayerComponent : IComponent
    {
        public Uid.Uid Player;
    }
}