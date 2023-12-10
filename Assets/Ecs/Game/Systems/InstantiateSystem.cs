using System.Collections.Generic;
using Ecs.EntityRepository;
using JCMG.EntitasRedux;
using Services.Spawn;

namespace Ecs.Game.Systems
{
    public class InstantiateSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;
        private readonly ISpawnService _spawnService;
        private readonly ILinkedEntityRepository _entityRepository;

        public InstantiateSystem(
            GameContext game, 
            ISpawnService spawnService, ILinkedEntityRepository entityRepository) : base(game)
        {
            _game = game;
            _spawnService = spawnService;
            _entityRepository = entityRepository;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Instantiate.Added());

        protected override bool Filter(GameEntity entity) => entity.IsInstantiate && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var view = _spawnService.Spawn(entity);
                
                view.Link(entity, _game);
                
                entity.ReplaceLink(view);
                
                _entityRepository.Add(view.Transform.GetInstanceID(), entity);
            }
        }
    }
}