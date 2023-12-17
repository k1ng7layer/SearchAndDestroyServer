using Core.Systems;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Game.Systems
{
    public class MoveDirectionSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;

        private readonly IGroup<GameEntity> _movableGroup;

        public MoveDirectionSystem(GameContext game)
        {
            _movableGroup = game.GetGroup(GameMatcher.Input);
        }
        
        public void Update()
        {
            var movables = EntityPool.Spawn();
            _movableGroup.GetEntities(movables);

            foreach (var movable in movables)
            {
                var inputDirection = movable.Input.Value;
                
                movable.ReplaceMoveDirection(inputDirection);
            }
            
            EntityPool.Despawn(movables);
        }
    }
}