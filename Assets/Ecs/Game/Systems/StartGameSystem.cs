using System.Collections.Generic;
using JCMG.EntitasRedux;
using Utils;

namespace Ecs.Game.Systems
{
    public class StartGameSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public StartGameSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Instantiate);

        protected override bool Filter(GameEntity entity) => 
            entity.IsInstantiate 
            && _game.GameMode.Value == EGameMode.Preparing 
            && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                _game.ReplaceGameMode(EGameMode.Countdown);
            }
        }
    }
}