using System;
using System.Linq;
using Mirror;
using NetworkMessages;
using Services.Network;
using UnityEngine;
using Zenject;

namespace Services.PlayerInput.impl
{
    public class NetworkInputService : IPlayerInputService, 
        IInitializable,
        IDisposable
    {
        private readonly INetworkServerManager _networkServerManager;
        private readonly GameContext _game;

        public NetworkInputService(
            INetworkServerManager networkServerManager, 
            GameContext game)
        {
            _networkServerManager = networkServerManager;
            _game = game;
        }

        public void Initialize()
        {
            _networkServerManager.RegisterMessageHandler<PlayerInputMessage>(OnPlayerInput);
            _networkServerManager.RegisterMessageHandler<PlayerRotationMessage>(OnPlayerRotationInput);
        }
        
        public void Dispose()
        {
            _networkServerManager.UnRegisterMessageHandler<PlayerInputMessage>();
            _networkServerManager.UnRegisterMessageHandler<PlayerRotationMessage>();
        }

        private void OnPlayerInput(NetworkConnectionToClient connection,
            PlayerInputMessage msg, 
            int connNum)
        {
            var playerEntity = _game.GetEntitiesWithConnectionId(connection.connectionId);
            
            if (playerEntity == null)
                return;

            var target = playerEntity.FirstOrDefault();

            if (target != null && target.HasAttached)
            {
                var attached = target.Attached.Carrier;
                
                target = _game.GetEntityWithUid(attached);
            }
            
            Debug.Log($"OnPlayerInput, connId: {connection.connectionId}");
            if (target != null) target.ReplaceInput(new Vector3(msg.X, msg.Y, msg.Z));
        }
        
        private void OnPlayerRotationInput(
            NetworkConnectionToClient connection,
            PlayerRotationMessage msg, 
            int connNum
        )
        {
            var playerEntity = _game.GetEntitiesWithConnectionId(connection.connectionId);
            
            if (playerEntity == null)
                return;
            
            Debug.Log($"OnPlayerInput, connId: {connection.connectionId}");
            playerEntity.FirstOrDefault()?.ReplaceInputRotation(msg.YEuler);
        }
    }
}