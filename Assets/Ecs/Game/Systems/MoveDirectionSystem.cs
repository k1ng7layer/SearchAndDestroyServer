using Core.Systems;
using JCMG.EntitasRedux;
using Utils;
using Zenject;

namespace Ecs.Game.Systems
{
    public class MoveDirectionSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;

        private readonly IGroup<GameEntity> _movableGroup;
        private readonly GameContext _game;

        public MoveDirectionSystem(GameContext game)
        {
            _game = game;
            _movableGroup = game.GetGroup(GameMatcher.Input);
        }
        
        public void Update()
        {
            if (_game.HasGameState && _game.GameState.Value == EGameState.Default)
                return;
            
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