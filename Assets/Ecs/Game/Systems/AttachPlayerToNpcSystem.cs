using System.Collections.Generic;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Systems
{
    public class AttachPlayerToNpcSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public AttachPlayerToNpcSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Attached);

        protected override bool Filter(GameEntity entity) => entity.HasAttached && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var carrierUid = entity.Attached.Carrier;
                var carrier = _game.GetEntityWithUid(carrierUid);
                var carrierTransform = carrier.Transform.Value;
                var playerTransform = entity.Transform.Value;
                
                playerTransform.SetParent(carrierTransform);
                playerTransform.localPosition = Vector3.zero;
            }
        }
    }
}