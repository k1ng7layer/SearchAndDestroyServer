using JCMG.EntitasRedux;
using Utils;

namespace Ecs.Game.Components
{
    [Game]
    [Unique]
    public class GameStateComponent : IComponent
    {
        public EGameState Value;
    }
}