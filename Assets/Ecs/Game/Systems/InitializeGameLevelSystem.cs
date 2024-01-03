using JCMG.EntitasRedux;
using Services.LevelObjectProvider;
using Utils;

namespace Ecs.Game.Systems
{
    public class InitializeGameLevelSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly ActionContext _action;
        private readonly ILevelObjectsHolder _levelObjectsHolder;

        public InitializeGameLevelSystem(
            GameContext game, 
            ActionContext action, 
            ILevelObjectsHolder levelObjectsHolder)
        {
            _game = game;
            _action = action;
            _levelObjectsHolder = levelObjectsHolder;
        }
        
        public void Initialize()
        {
            _game.ReplaceGameState(EGameState.Preparing);
            
            var objectsHolder = _levelObjectsHolder.CommonObjectsHolder;

            foreach (var spawnTransform in objectsHolder.NpcSpawnTransforms)
            {
                _action.CreateEntity().AddSpawnNpc(spawnTransform.position, spawnTransform.rotation);
            }
            
            //_action.CreateEntity().AddSpawnNpc(objectsHolder.NpcSpawnTransforms[0].position, objectsHolder.NpcSpawnTransforms[0].rotation);
        }
    }
}