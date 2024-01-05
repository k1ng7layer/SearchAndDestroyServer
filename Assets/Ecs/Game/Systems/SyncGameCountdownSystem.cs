using System.Collections.Generic;
using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;
using UnityEngine;
using Utils;

namespace Ecs.Game.Systems
{
    public class SyncGameCountdownSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;
        private readonly INetworkServerManager _serverManager;

        public SyncGameCountdownSystem(
            GameContext game, 
            INetworkServerManager serverManager
        ) : base(game)
        {
            _game = game;
            _serverManager = serverManager;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GameCountdown);

        protected override bool Filter(GameEntity entity) 
            => entity.HasGameCountdown 
               && _game.GameState.Value != EGameState.Default 
               && !entity.IsDestroyed;

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