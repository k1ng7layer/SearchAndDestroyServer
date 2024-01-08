using System;
using System.Linq;
using JCMG.EntitasRedux;
using Models;
using Services.PlayerInput;
using UnityEngine;

namespace Ecs.Game.Systems
{
    public class ReadPlayerMovementSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly IPlayerInputService _playerInputService;
        private readonly GameContext _game;

        public ReadPlayerMovementSystem(
            IPlayerInputService playerInputService, 
            GameContext game
        )
        {
            _playerInputService = playerInputService;
            _game = game;
        }
        
        public void Initialize()
        {
            _playerInputService.InputRotation += OnPlayerRotationInput;
            _playerInputService.InputDirection += OnPlayerDirectionInput;
        }
        
        public void Dispose()
        {
            _playerInputService.InputRotation -= OnPlayerRotationInput;
            _playerInputService.InputDirection -= OnPlayerDirectionInput;
        }

        private void OnPlayerDirectionInput(Player player, Vector3 direction)
        {
            var playerEntity = _game.GetEntitiesWithConnectionId(player.ConnectionId);
            
            if (playerEntity == null)
                return;

            var target = playerEntity.FirstOrDefault();

            if (target != null && target.HasAttached)
            {
                var attached = target.Attached.Carrier;
                
                target = _game.GetEntityWithUid(attached);
            }
            
            if (target != null) target.ReplaceInput(direction);
        }

        private void OnPlayerRotationInput(Player player, float y)
        {
            var playerEntity = _game.GetEntitiesWithConnectionId(player.ConnectionId);
            
            if (playerEntity == null)
                return;
            
            playerEntity.FirstOrDefault()?.ReplaceInputRotation(y);
        }
    }
}