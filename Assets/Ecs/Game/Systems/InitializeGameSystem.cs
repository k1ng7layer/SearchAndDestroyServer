using JCMG.EntitasRedux;
using Utils;

namespace Ecs.Game.Systems
{
    public class InitializeGameSystem : IInitializeSystem
    {
        private readonly GameContext _game;

        public InitializeGameSystem(GameContext game)
        {
            _game = game;
        }
        
        public void Initialize()
        {
            _game.ReplaceGameMode(EGameMode.Preparing);
            
        }
    }
}