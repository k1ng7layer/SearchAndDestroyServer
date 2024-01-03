using System.Collections.Generic;
using JCMG.EntitasRedux;
using Settings.Player;
using Utils;
using Zenject;

namespace Ecs.Game.Systems
{
    public class InitializeGameStateSystem : ReactiveSystem<GameEntity>
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly GameContext _game;
        private readonly IPlayerSettings _playerSettings;
        private readonly IGroup<GameEntity> _playerGroup;

        public InitializeGameStateSystem(
            GameContext game, 
            IPlayerSettings playerSettings) : base(game)
        {
            _game = game;
            _playerSettings = playerSettings;
            _playerGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player).NoneOf(GameMatcher.Destroyed));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GameCountdown.Removed());

        protected override bool Filter(GameEntity entity) => 
            !entity.HasGameCountdown &&
            _game.GameState.Value == EGameState.Countdown &&
            !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var players = EntityPool.Spawn();
                _playerGroup.GetEntities(players);

                foreach (var player in players)
                {
                    player.ReplaceTimer(_playerSettings.MaxDetachedTime);
                }
                
                EntityPool.Despawn(players);
            }
        }
    }
}