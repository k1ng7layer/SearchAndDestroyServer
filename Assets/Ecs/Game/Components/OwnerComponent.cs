using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class OwnerComponent : IComponent
    {
        public Uid.Uid Value;
    }
}