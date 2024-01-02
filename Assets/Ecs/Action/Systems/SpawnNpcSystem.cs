using System.Collections.Generic;
using Db.Prefabs;
using Ecs.Uid;
using Ecs.Views.Linkable;
using JCMG.EntitasRedux;
using Mirror;
using Services.Network;
using UnityEngine;

namespace Ecs.Action.Systems
{
    public class SpawnNpcSystem : ReactiveSystem<ActionEntity> 
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly IPrefabsBase _prefabsBase;
        private readonly INetworkServerManager _serverManager;

        public SpawnNpcSystem(ActionContext action, 
            GameContext game, 
            IPrefabsBase prefabsBase,
            INetworkServerManager serverManager) : base(action)
        {
            _action = action;
            _game = game;
            _prefabsBase = prefabsBase;
            _serverManager = serverManager;
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
                var npcGO = Object.Instantiate(prefab.gameObject, spawnPosition, spawnRotation);
                var view = npcGO.GetComponent<ILinkableView>();
                var identity = npcGO.GetComponent<NetworkIdentity>();
                
                npcEntity.IsNpc = true;
                npcEntity.AddPosition(spawnPosition);
                npcEntity.AddRotation(spawnRotation);
                npcEntity.AddUid(uid);
                npcEntity.AddLink(view);
            
                view.Link(npcEntity, _game);
                
                NetworkServer.Spawn(npcGO);
                
                
                npcEntity.AddNetworkId(identity.netId);
                
                npcEntity.IsInstantiate = true;
                npcEntity.IsAi = true;
                
                _action.CreateEntity().AddChooseDestination(uid);
            }
        }
    }
}