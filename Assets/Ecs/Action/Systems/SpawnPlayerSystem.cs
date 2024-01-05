using System.Collections.Generic;
using Db.Prefabs;
using Ecs.Game.Extensions;
using Ecs.Views.Linkable;
using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using Mirror;
using Services.LevelObjectProvider;
using UnityEngine;

namespace Ecs.Action.Systems
{
    public class SpawnPlayerSystem : ReactiveSystem<ActionEntity>
    {
        private readonly IPrefabsBase _prefabsBase;
        private readonly GameContext _game;
        private readonly ILevelObjectsHolder _levelObjectsHolder;

        public SpawnPlayerSystem(
            ActionContext action, 
            IPrefabsBase prefabsBase,
            GameContext game,
            ILevelObjectsHolder levelObjectsHolder
        ) : base(action)
        {
            _prefabsBase = prefabsBase;
            _game = game;
            _levelObjectsHolder = levelObjectsHolder;
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
                
                //TODO:temp
                if (!NetworkServer.connections.ContainsKey(connIndex))
                    continue;
                
                var connection = NetworkServer.connections[connIndex];
                
                var prefab = _prefabsBase.Get("Player2");

                var spawnPos = _levelObjectsHolder.CommonObjectsHolder.PlayerSpawnTransform;

                var position = spawnPos.position;
                var rotation = spawnPos.rotation;
                
                var obj = Object.Instantiate(prefab.gameObject, position, rotation);
                
                Debug.Log($"spawn player for connection id: {connection.connectionId}");

                var playerEntity = _game.CreatePlayer(connection.connectionId, position, rotation);
            
                var view = obj.GetComponent<ILinkableView>();
            
                playerEntity.AddLink(view);
            
                view.Link(playerEntity, _game);

                playerEntity.IsInstantiate = true;
                
                NetworkServer.AddPlayerForConnection(connection, obj);
                
                var playerView = (PlayerView)view;
                var identity = playerView.GetComponent<NetworkIdentity>();
            
                playerEntity.AddNetworkId(identity.netId);
            }
        }
    }
}