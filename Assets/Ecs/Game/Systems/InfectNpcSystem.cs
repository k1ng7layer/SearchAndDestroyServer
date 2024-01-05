using System;
using System.Linq;
using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using Mirror;
using NetworkMessages;
using Services.Network;
using UnityEngine;

namespace Ecs.Game.Systems
{
    public class InfectNpcSystem : IInitializeSystem, IDisposable
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
        
        public void Dispose()
        {
            _serverManager.UnRegisterMessageHandler<InfectNpcMessage>();
        }

        private void OnInfectNpc(
            NetworkConnectionToClient conn, 
            InfectNpcMessage msg, 
            int id)
        {
            Debug.Log($"OnInfectNpc npc id: {msg.NpcId}");
            var player = _game.GetEntitiesWithConnectionId(conn.connectionId).FirstOrDefault();
         
            var npc = _game.GetEntityWithNetworkId(msg.NpcId);
            
            if (npc.HasAttached)
                return;
            
            var npcUid = npc.Uid.Value;

            if (player != null)
            {
                player.ReplaceAttached(npcUid);
                player.ReplaceTimer(10f);

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
}