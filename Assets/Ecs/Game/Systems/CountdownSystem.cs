using JCMG.EntitasRedux;
using Services.TimeProvider;

namespace Ecs.Game.Systems
{
    public class CountdownSystem : IUpdateSystem
    {
        private readonly GameContext _game;
        private readonly ITimeProvider _timeProvider;

        public CountdownSystem(
            GameContext game, 
            ITimeProvider timeProvider
        )
        {
            _game = game;
            _timeProvider = timeProvider;
        }
        
        public void Update()
        {
            if (!_game.HasGameCountdown)
                return;
            
            var countdown = _game.GameCountdown.Value;
            
            countdown -= _timeProvider.DeltaTime;
            
            _game.ReplaceGameCountdown(countdown);
            
            if (countdown == 0)
                _game.RemoveGameCountdown();
        }
    }
}