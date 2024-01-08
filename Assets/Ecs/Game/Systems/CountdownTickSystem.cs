using JCMG.EntitasRedux;
using Services.TimeProvider;
using Utils;

namespace Ecs.Game.Systems
{
    public class CountdownTickSystem : IUpdateSystem
    {
        private readonly GameContext _game;
        private readonly ITimeProvider _timeProvider;

        public CountdownTickSystem(
            GameContext game, 
            ITimeProvider timeProvider
        )
        {
            _game = game;
            _timeProvider = timeProvider;
        }
        
        public void Update()
        {
            if (_game.HasGameState && _game.GameState.Value == EGameState.Default)
                return;
            
            if (!_game.HasGameCountdown)
                return;
            
            var countdown = _game.GameCountdown.Value;
            
            countdown -= _timeProvider.DeltaTime;
            
            _game.ReplaceGameCountdown(countdown);

            if (!(countdown <= 0)) return;
            
            _game.ReplaceGameCountdown(0);
            _game.RemoveGameCountdown();
        }
    }
}