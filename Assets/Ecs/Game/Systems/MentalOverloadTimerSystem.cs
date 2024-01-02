using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;
using Services.TimeProvider;
using UnityEngine;
using Zenject;

namespace Ecs.Game.Systems
{
    public class MentalOverloadTimerSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;

        private readonly ITimeProvider _timeProvider;
        private readonly INetworkServerManager _serverManager;
        private readonly IGroup<GameEntity> _attachedParasites;
        private readonly ActionContext _action;

        public MentalOverloadTimerSystem(
            ITimeProvider timeProvider,
            INetworkServerManager serverManager,
            GameContext game,
            ActionContext action
        )
        {
            _timeProvider = timeProvider;
            _serverManager = serverManager;
            _action = action;

            _attachedParasites = game.GetGroup(GameMatcher.AllOf(GameMatcher.Attached, GameMatcher.Timer));
        }
        
        public void Update()
        {
            var attachedPlayers = EntityPool.Spawn();
            _attachedParasites.GetEntities(attachedPlayers);

            foreach (var attachedPlayer in attachedPlayers)
            {
                var timer = attachedPlayer.Timer.Value;
                timer -= _timeProvider.DeltaTime;

                timer = Mathf.Clamp(0, timer, float.MaxValue);
                
                attachedPlayer.ReplaceTimer(timer);

                var connId = attachedPlayer.ConnectionId.Value;
                
                _serverManager.SendTo(connId, new MentalOverloadTimerMessage
                {
                    Value = timer
                });

                if (timer == 0)
                {
                    attachedPlayer.RemoveTimer();
                    var playerUid = attachedPlayer.Uid.Value;
                    
                    _action.CreateEntity().AddDetachPlayer(playerUid);
                }
                    
            }
            
            EntityPool.Despawn(attachedPlayers);
        }
    }
}