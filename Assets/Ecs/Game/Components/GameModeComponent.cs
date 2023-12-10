using JCMG.EntitasRedux;
using Utils;

namespace Ecs.Game.Components
{
    [Game]
    [Unique]
    public class GameModeComponent : IComponent
    {
        public EGameMode Value;
    }
}