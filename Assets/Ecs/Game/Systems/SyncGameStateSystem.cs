using System.Collections.Generic;
using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;

namespace Ecs.Game.Systems
{
    public class SyncGameStateSystem : ReactiveSystem<GameEntity>
    {
        private readonly INetworkServerManager _networkServerManager;

        public SyncGameStateSystem(
            GameContext game, 
            INetworkServerManager networkServerManager
        ) : base(game)
        {
            _networkServerManager = networkServerManager;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GameState);

        protected override bool Filter(GameEntity entity) => entity.HasGameState && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var currentState = entity.GameState.Value;
                
                // _networkServerManager.SendToAll(new ServerGameStateMessage
                // {
                //     GameState = (byte)currentState
                // });
            }
        }
    }
}