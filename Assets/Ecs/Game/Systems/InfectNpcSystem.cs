using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using Mirror;
using NetworkMessages;
using Services.Network;
using UnityEngine;

namespace Ecs.Game.Systems
{
    public class InfectNpcSystem : IInitializeSystem
    {
        private readonly INetworkServerManager _serverManager;
        private readonly GameContext _game;

        public InfectNpcSystem(INetworkServerManager serverManager, GameContext game)
        {
            _serverManager = serverManager;
            _game = game;
        }
        
        public void Initialize()
        {
            _serverManager.RegisterMessageHandler<InfectNpcMessage>(OnInfectNpc);
        }

        private void OnInfectNpc(
            NetworkConnectionToClient conn, 
            InfectNpcMessage msg, 
            int id)
        {
            Debug.Log($"OnInfectNpc npc id: {msg.NpcId}");
            var player = _game.GetEntityWithConnectionId(conn.connectionId);
         
            var npc = _game.GetEntityWithNetworkId(msg.NpcId);
            var npcUid = npc.Uid.Value;
            
            player.ReplaceAttached(npcUid);
            
            npc.IsAi = false;
            var view = (NetworkObjectView)npc.Link.View;
            var identity = view.GetComponent<NetworkIdentity>();
            //
            identity.AssignClientAuthority(conn);

            _serverManager.SendToAll(new AttachPlayerToNpcMessage
            {
                PlayerId = player.NetworkId.Value,
                NpcNetId = msg.NpcId
            });
        }
    }
}