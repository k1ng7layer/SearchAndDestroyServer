using System.Collections.Generic;
using Db.Prefabs;
using Ecs.Uid;
using Ecs.Views.Linkable;
using JCMG.EntitasRedux;
using Mirror;
using UnityEngine;

namespace Ecs.Action.Systems
{
    public class SpawnNpcSystem : ReactiveSystem<ActionEntity> 
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly IPrefabsBase _prefabsBase;

        public SpawnNpcSystem(ActionContext action, GameContext game, IPrefabsBase prefabsBase) : base(action)
        {
            _action = action;
            _game = game;
            _prefabsBase = prefabsBase;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.SpawnNpc);

        protected override bool Filter(ActionEntity entity) => entity.HasSpawnNpc && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var prefab = _prefabsBase.Get("Npc");
                var spawnPosition = entity.SpawnNpc.Position;
                var spawnRotation = entity.SpawnNpc.Rotation;
                var npcEntity = _game.CreateEntity();
                var uid = UidGenerator.Next();
                
                npcEntity.IsNpc = true;
                npcEntity.AddPosition(spawnPosition);
                npcEntity.AddRotation(spawnRotation);
                npcEntity.AddUid(uid);

                var npcGO = Object.Instantiate(prefab.gameObject, spawnPosition, spawnRotation);
                
                var view = npcGO.GetComponent<ILinkableView>();
            
                npcEntity.AddLink(view);
            
                view.Link(npcEntity, _game);

                npcEntity.IsInstantiate = true;
                
                _action.CreateEntity().AddChooseDestination(uid);
            }
        }
    }
}