using System.Collections.Generic;
using JCMG.EntitasRedux;
using Settings.Common;
using Utils;

namespace Ecs.Game.Systems
{
    public class StartPreparingCountdownSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;
        private readonly ICommonGameSettings _commonGameSettings;

        public StartPreparingCountdownSystem(
            GameContext game, 
            ICommonGameSettings commonGameSettings
        ) : base(game)
        {
            _game = game;
            _commonGameSettings = commonGameSettings;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GameState);

        protected override bool Filter(GameEntity entity) =>
            entity.HasGameState && entity.GameState.Value == EGameState.Countdown;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var _ in entities)
            {
                var time = _commonGameSettings.PreparingTime;
                
                _game.ReplaceGameCountdown(time);
            }
        }
    }
}