using System.Collections.Generic;
using JCMG.EntitasRedux;
using Utils;

namespace Ecs.Game.Systems
{
    public class StartCountdownSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public StartCountdownSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GameMode);

        protected override bool Filter(GameEntity entity) =>
            entity.HasGameMode && entity.GameMode.Value == EGameMode.Countdown;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                
            }
        }
    }
}