using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems
{
    public class MentalOverloadSystem : ReactiveSystem<GameEntity>
    {
        private readonly ActionContext _action;

        public MentalOverloadSystem(
            GameContext game, 
            ActionContext action
        ) : base(game)
        {
            _action = action;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Timer.Removed());

        protected override bool Filter(GameEntity entity) => entity.IsPlayer && entity.HasAttached && !entity.HasTimer &&  !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var playerUid = entity.Uid.Value;
                    
                _action.CreateEntity().AddDetachPlayer(playerUid);
            }
        }
    }
}