using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
    [Action]
    public class ChooseDestinationComponent : IComponent
    {
        public Uid.Uid NpcUid;
    }
}