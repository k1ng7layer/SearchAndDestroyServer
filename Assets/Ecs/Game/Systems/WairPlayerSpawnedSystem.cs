using System.Collections.Generic;
using JCMG.EntitasRedux;
using Utils;

namespace Ecs.Game.Systems
{
    public class WairPlayerSpawnedSystem : ReactiveSystem<GameEntity>
    {
        private const int MaxPlayers = 1;
        
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _spawnedPlayerGroup;

        public WairPlayerSpawnedSystem(GameContext game) : base(game)
        {
            _game = game;

            _spawnedPlayerGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Instantiate);

        protected override bool Filter(GameEntity entity) => 
            entity.IsInstantiate 
            && entity.IsPlayer
            && _game.GameState.Value == EGameState.Preparing 
            && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (AllSpawned())
                    _game.ReplaceGameState(EGameState.Countdown);
            }
        }

        private bool AllSpawned()
        {
            int temp = 0;

            foreach (var spawned in _spawnedPlayerGroup)
            {
                if (spawned.IsInstantiate)
                    temp++;
            }

            return temp == MaxPlayers;
        }
    }
}