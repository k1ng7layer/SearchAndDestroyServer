using System;
using System.Linq;
using Mirror;
using Models;
using NetworkMessages;
using Services.Network;
using Services.PlayerRepository;
using UnityEngine;
using Zenject;

namespace Services.PlayerInput.impl
{
    public class NetworkInputService : IPlayerInputService, 
        IInitializable,
        IDisposable
    {
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPlayerRepository _playerRepository;

        public NetworkInputService(
            INetworkServerManager networkServerManager,
            IPlayerRepository playerRepository
        )
        {
            _networkServerManager = networkServerManager;
            _playerRepository = playerRepository;
        }
        
        public event Action<Player, float> InputRotation;
        public event Action<Player, Vector3> InputDirection;

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
            if (!_playerRepository.TryGet(connection.connectionId, out var player)) return;
            
            var dir = new Vector3(msg.X, msg.Y, msg.Z);
            
            InputDirection?.Invoke(player, dir);
        }
        
        private void OnPlayerRotationInput(
            NetworkConnectionToClient connection,
            PlayerRotationMessage msg, 
            int connNum
        )
        {
            if (!_playerRepository.TryGet(connection.connectionId, out var player)) return;
            
            InputRotation?.Invoke(player, msg.YEuler);
        }
    }
}