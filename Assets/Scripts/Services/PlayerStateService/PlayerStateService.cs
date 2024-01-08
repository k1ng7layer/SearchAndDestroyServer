using System;
using System.Collections.Generic;
using Mirror;
using NetworkMessages;
using Services.Network;
using Services.PlayerRepository;
using UniRx.Async;
using Utils;
using Zenject;

namespace Services.PlayerStateService
{
    public class PlayerStateService : IInitializable, IDisposable
    {
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPlayerRepository _playerRepository;
        private readonly Dictionary<int, byte> _clientStates = new();
        private UniTaskCompletionSource _taskCompletionSource;
        private EGameState _currentState;

        public PlayerStateService(
            INetworkServerManager networkServerManager, 
            IPlayerRepository playerRepository
        )
        {
            _networkServerManager = networkServerManager;
            _playerRepository = playerRepository;
        }
        
        public void Initialize()
        {
            _networkServerManager.RegisterMessageHandler<ClientChangeStateMessage>(OnClientChangeState);
        }
        
        public void Dispose()
        {
            _networkServerManager.UnRegisterMessageHandler<ClientChangeStateMessage>();
        }
        
        public UniTask ChangeClientsStateAsync(EGameState gameState)
        {
            if (_playerRepository.Players.Count == 0)
                return UniTask.CompletedTask;
            
            _currentState = gameState;
            _taskCompletionSource = new UniTaskCompletionSource();
            
            _networkServerManager.SendToAll(new ServerGameStateMessage
            {
                GameState = (byte)gameState
            });

            return _taskCompletionSource.Task;
        }

        private void OnClientChangeState(NetworkConnectionToClient conn, 
            ClientChangeStateMessage msg,
            int id)
        {
            if ((EGameState)msg.State == _currentState)
                _clientStates.Add(conn.connectionId, msg.State);
            
            if (_clientStates.Count != _playerRepository.Players.Count) return;

            foreach (var kvp in _clientStates)
            {
                if (kvp.Value != (byte)_currentState)
                    return;
            }

            _clientStates.Clear();
            _taskCompletionSource.TrySetResult();
        }
    }
}