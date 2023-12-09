using Ecs.Views.Linkable;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    [Event(EventTarget.Self, EventType.Removed)]
    public class LinkComponent : IComponent
    {
        public ILinkableView View;
    }
}