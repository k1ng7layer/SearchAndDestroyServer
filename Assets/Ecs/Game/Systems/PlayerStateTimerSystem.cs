﻿using JCMG.EntitasRedux;
using NetworkMessages;
using Services.Network;
using Services.TimeProvider;
using UnityEngine;
using Utils;
using Zenject;

namespace Ecs.Game.Systems
{
    public class PlayerStateTimerSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;

        private readonly ITimeProvider _timeProvider;
        private readonly INetworkServerManager _serverManager;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _attachedParasites;
        private readonly ActionContext _action;

        public PlayerStateTimerSystem(
            ITimeProvider timeProvider,
            INetworkServerManager serverManager,
            GameContext game,
            ActionContext action
        )
        {
            _timeProvider = timeProvider;
            _serverManager = serverManager;
            _game = game;
            _action = action;

            _attachedParasites = game.GetGroup(GameMatcher.AllOf(GameMatcher.Timer));
        }
        
        public void Update()
        {
            if (_game.HasGameState && _game.GameState.Value == EGameState.Default)
            {
                Debug.Log($"TEST PlayerStateTimerSystem return");
                return;
            }
            
            var attachedPlayers = EntityPool.Spawn();
            _attachedParasites.GetEntities(attachedPlayers);
            
            foreach (var attachedPlayer in attachedPlayers)
            {
                var timer = attachedPlayer.Timer.Value;
                timer -= _timeProvider.DeltaTime;

                timer = Mathf.Clamp(timer, 0, float.MaxValue);
                
                attachedPlayer.ReplaceTimer(timer);

                var connId = attachedPlayer.ConnectionId.Value;
                
                Debug.Log($"PlayerStateTimerSystem: {timer}");
                _serverManager.SendTo(connId, new PlayerStateTimerMessage
                {
                    Value = timer
                });

                if (timer == 0)
                {
                    attachedPlayer.RemoveTimer();
                }
            }
            
            EntityPool.Despawn(attachedPlayers);
        }
    }
}