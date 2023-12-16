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
        }

        private void OnPlayerInput(NetworkConnectionToClient connection,
            PlayerInputMessage msg, 
            int connNum)
        {
            var playerEntity = _game.GetEntityWithConnectionId(connection.connectionId);
            
            if (playerEntity == null)
                return;
            
            playerEntity.ReplaceInput(new Vector3(msg.X, msg.Y, msg.Z));
        }
    }
}