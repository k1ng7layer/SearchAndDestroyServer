using Db.Prefabs;
using Ecs.Game.Extensions;
using Ecs.Views.Linkable;
using JCMG.EntitasRedux;
using Mirror;
using NetworkMessages;
using Services.Network;
using UnityEngine;

namespace Ecs.Game.Systems
{
    public class SpawnPlayerSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPrefabsBase _prefabsBase;

        public SpawnPlayerSystem(
            GameContext game, 
            INetworkServerManager networkServerManager, 
            IPrefabsBase prefabsBase
        )
        {
            _game = game;
            _networkServerManager = networkServerManager;
            _prefabsBase = prefabsBase;
        }
        
        public void Initialize()
        {
            _networkServerManager.RegisterMessageHandler<SpawnPlayerMessage>(SpawnPlayer);
        }

        private void SpawnPlayer(
            NetworkConnectionToClient conn, 
            SpawnPlayerMessage message, 
            int id
        )
        {
            var prefab = _prefabsBase.Get("Player2");

            var obj = Object.Instantiate(prefab.gameObject);

            var playerEntity = _game.CreatePlayer(conn.connectionId, Vector3.zero, Quaternion.identity);
            
            var view = obj.GetComponent<ILinkableView>();
            
            playerEntity.AddLink(view);
            
            view.Link(playerEntity, _game);

            playerEntity.IsInstantiate = true;

            NetworkServer.AddPlayerForConnection(conn, obj);
        }
    }
}