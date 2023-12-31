using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class AttachedComponent : IComponent
    {
        public Uid.Uid Carrier;
    }
}