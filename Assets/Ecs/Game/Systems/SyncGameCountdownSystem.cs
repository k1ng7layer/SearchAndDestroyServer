using System.Collections.Generic;
using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;
using UnityEngine;

namespace Ecs.Game.Systems
{
    public class SyncGameCountdownSystem : ReactiveSystem<GameEntity>
    {
        private readonly INetworkServerManager _serverManager;

        public SyncGameCountdownSystem(
            GameContext game, 
            INetworkServerManager serverManager
        ) : base(game)
        {
            _serverManager = serverManager;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GameCountdown);

        protected override bool Filter(GameEntity entity) => entity.HasGameCountdown && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var countdown = entity.GameCountdown.Value;
                
                //Debug.Log($"SyncGameCountdownSystem: {countdown}");
                
                _serverManager.SendToAll(new GameCountdownMessage
                {
                    Value = countdown
                });
            }
        }
    }
}