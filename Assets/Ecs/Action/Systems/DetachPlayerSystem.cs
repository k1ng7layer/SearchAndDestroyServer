using System.Collections.Generic;
using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;

namespace Ecs.Action.Systems
{
    public class DetachPlayerSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly INetworkServerManager _networkServerManager;

        public DetachPlayerSystem(
            ActionContext action, 
            GameContext game,
            INetworkServerManager networkServerManager
        ) : base(action)
        {
            _game = game;
            _networkServerManager = networkServerManager;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.DetachPlayer);

        protected override bool Filter(ActionEntity entity) => entity.HasDetachPlayer && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var playerUid = entity.DetachPlayer.Player;
                var player = _game.GetEntityWithUid(playerUid);
                var attached = player.Attached.Carrier;
                var npc = _game.GetEntityWithUid(attached);
                
                var playerTransform = player.Transform.Value;
                
                playerTransform.SetParent(null);
                player.RemoveAttached();
                
                npc.IsAi = true;
              
                _networkServerManager.SendToAll(new DetachPlayerToNpcMessage
                {
                    PlayerId = player.NetworkId.Value,
                    NpcNetId = npc.NetworkId.Value
                });
            }
        }
    }
}