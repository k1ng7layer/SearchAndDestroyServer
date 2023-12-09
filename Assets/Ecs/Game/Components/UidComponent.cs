using JCMG.EntitasRedux;

namespace Ecs.Game.Components
{
    [Game]
    public class UidComponent : IComponent
    {
        [PrimaryEntityIndex] public Uid.Uid Value;
        
        public override string ToString() => Value.ToString();
    }
}