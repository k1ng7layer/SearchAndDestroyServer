using System.Collections.Generic;
using Db.Prefabs;
using Ecs.Game.Extensions;
using Ecs.Views.Linkable;
using JCMG.EntitasRedux;
using Mirror;
using UnityEngine;

namespace Ecs.Action.Systems
{
    public class SpawnPlayerSystem : ReactiveSystem<ActionEntity>
    {
        private readonly IPrefabsBase _prefabsBase;
        private readonly GameContext _game;

        public SpawnPlayerSystem(
            ActionContext action, 
            IPrefabsBase prefabsBase,
            GameContext game
        ) : base(action)
        {
            _prefabsBase = prefabsBase;
            _game = game;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.SpawnPlayer);

        protected override bool Filter(ActionEntity entity) => entity.HasSpawnPlayer && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var connIndex = entity.SpawnPlayer.ConnectionIndex;
                var connection = NetworkServer.connections[connIndex];
                
                var prefab = _prefabsBase.Get("Player2");

                var obj = Object.Instantiate(prefab.gameObject);

                var playerEntity = _game.CreatePlayer(connection.connectionId, Vector3.zero, Quaternion.identity);
            
                var view = obj.GetComponent<ILinkableView>();
            
                playerEntity.AddLink(view);
            
                view.Link(playerEntity, _game);

                playerEntity.IsInstantiate = true;
                
                NetworkServer.AddPlayerForConnection(connection, obj);
            }
        }
    }
}