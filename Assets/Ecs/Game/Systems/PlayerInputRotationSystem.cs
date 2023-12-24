using JCMG.EntitasRedux;
using UnityEngine;
using Zenject;

namespace Ecs.Game.Systems
{
    public class PlayerInputRotationSystem : IUpdateSystem
    {
        private const float TurnSmoothTime = 0.1f;
        
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly IGroup<GameEntity> _rotationGroup;
        private float TurnSmoothVelocity;
        
        public PlayerInputRotationSystem(GameContext game)
        {
            _rotationGroup = game.GetGroup(GameMatcher.InputRotation);
        }
        
        public void Update()
        {
            var players = EntityPool.Spawn();
            _rotationGroup.GetEntities(players);

            foreach (var player in players)
            {
                if (player.IsDestroyed)
                    continue;
                
                var inputRotation = player.InputRotation.Value;
                
                if (!player.HasRotationVelocity)
                    player.AddRotationVelocity(0f);
                
                var rotationVelocity = player.RotationVelocity.Value;
                
                var angle = Mathf.SmoothDampAngle(player.Transform.Value.eulerAngles.y, inputRotation, ref rotationVelocity,
                    TurnSmoothTime);

                player.ReplaceRotationVelocity(rotationVelocity);
                
                var rotation = Quaternion.Euler(0f, angle, 0f);
                
                player.ReplaceRotation(rotation);
            }
            
            EntityPool.Despawn(players);
        }
    }
}