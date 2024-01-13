using System.Collections.Generic;
using System.Linq;
using Helpers;
using JCMG.EntitasRedux;
using Models;
using NetworkMessages;
using Services.Network;
using Services.PlayerRepository;

namespace Ecs.Action.Systems
{
    public class SendRolesWeirdSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly IPlayerRepository _playerRepository;
        private readonly INetworkServerManager _networkServerManager;

        public SendRolesWeirdSystem(
            ActionContext action, 
            GameContext game, 
            IPlayerRepository playerRepository,
            INetworkServerManager networkServerManager
        ) : base(action)
        {
            _game = game;
            _playerRepository = playerRepository;
            _networkServerManager = networkServerManager;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.SendRolesWeird);

        protected override bool Filter(ActionEntity entity) => entity.IsSendRolesWeird && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;
                
                var roles = new List<byte>();
                var netIds = new List<uint>();

                foreach (var kvp in  _playerRepository.Players)
                {
                    var player = _game.GetEntitiesWithConnectionId(kvp.Value.ConnectionId).First();
                    
                    roles.Add((byte)kvp.Value.Role);
                    netIds.Add(player.NetworkId.Value);
                }
                
                _networkServerManager.SendToAll(new SpawnedPlayersRolesMessage
                {
                    Roles = roles,
                    NetIds = netIds
                });
            }
        }
    }
}