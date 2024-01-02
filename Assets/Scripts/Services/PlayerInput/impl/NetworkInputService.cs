using Mirror;
using NetworkMessages;
using Services.Network;
using UnityEngine;
using Zenject;

namespace Services.PlayerInput.impl
{
    public class NetworkInputService : IPlayerInputService, 
        IInitializable
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

        private void OnPlayerInput(NetworkConnectionToClient connection,
            PlayerInputMessage msg, 
            int connNum)
        {
            var playerEntity = _game.GetEntityWithConnectionId(connection.connectionId);
            
            if (playerEntity == null)
                return;

            var target = playerEntity;

            if (playerEntity.HasAttached)
            {
                var attached = playerEntity.Attached.Carrier;
                
                target = _game.GetEntityWithUid(attached);
            }
            
            Debug.Log($"OnPlayerInput, connId: {connection.connectionId}");
            target.ReplaceInput(new Vector3(msg.X, msg.Y, msg.Z));
        }
        
        private void OnPlayerRotationInput(
            NetworkConnectionToClient connection,
            PlayerRotationMessage msg, 
            int connNum
        )
        {
            var playerEntity = _game.GetEntityWithConnectionId(connection.connectionId);
            
            if (playerEntity == null)
                return;
            
            Debug.Log($"OnPlayerInput, connId: {connection.connectionId}");
            playerEntity.ReplaceInputRotation(msg.YEuler);
        }
    }
}