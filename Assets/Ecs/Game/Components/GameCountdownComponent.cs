using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Unique]
    [Game]
    [Event(EventTarget.Self)]
    public class GameCountdownComponent : IComponent
    {
        public float Value;
    }
}