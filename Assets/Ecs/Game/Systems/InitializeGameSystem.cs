using JCMG.EntitasRedux;
using Services.LevelObjectProvider;
using Utils;

namespace Ecs.Game.Systems
{
    public class InitializeGameSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly ActionContext _action;
        private readonly ILevelObjectsHolder _levelObjectsHolder;

        public InitializeGameSystem(
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
            var npcSpawnTransform = objectsHolder.NpcSpawnTransforms[0];
            
            _action.CreateEntity().AddSpawnNpc(npcSpawnTransform.position, npcSpawnTransform.rotation);
        }
    }
}