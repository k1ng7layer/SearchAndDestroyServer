using System;
using System.Collections.Generic;
using Mirror;
using NetworkMessages;
using Services.Network;
using Services.PlayerRepository;
using Services.SceneLoading;
using UniRx.Async;
using Utils;
using Zenject;

namespace Services.ClientLoading
{
    public class ClientLoadingService : IInitializable, IDisposable
    {
        private readonly INetworkServerManager _networkServerManager;
        private readonly IPlayerRepository _playerRepository;
        private readonly Dictionary<int, UniTaskCompletionSource> _clientLoadingTaskCompletionSources = new();
        private UniTaskCompletionSource _allClientsLoadedTcs;
        private ELevelName _pendingLevelName;

        public ClientLoadingService(
            INetworkServerManager networkServerManager, 
            IPlayerRepository playerRepository
        )
        {
            _networkServerManager = networkServerManager;
            _playerRepository = playerRepository;
        }

        public event Action<int> ClientLoaded;
        
        public void Initialize()
        {
            _networkServerManager.RegisterMessageHandler<PlayerLoadedMessage>(OnClientLoaded);
        }
        
        public void Dispose()
        {
            _networkServerManager.UnRegisterMessageHandler<PlayerLoadedMessage>();
        }
        
        public UniTask LoadLevelOnClientsAsync(ELevelName levelName)
        {
            if (_playerRepository.Players.Count == 0)
                return UniTask.CompletedTask;
            
            _pendingLevelName = levelName;
            _allClientsLoadedTcs = new UniTaskCompletionSource();
            
            _networkServerManager.SendToAll(new LevelLoadingMessage()
            {
                LevelName = levelName.ToString()
            });

            return _allClientsLoadedTcs.Task;
        }
        
        public UniTask WaitClientLoadedAsync(ELevelName levelName, int connectionId)
        {
            _pendingLevelName = levelName;
            
            var taskCompletionSource = new UniTaskCompletionSource();
            _clientLoadingTaskCompletionSources.Add(connectionId, taskCompletionSource);
            
            return _allClientsLoadedTcs.Task;
        }

        private void OnClientLoaded(NetworkConnectionToClient conn, 
            PlayerLoadedMessage _,
            int id)
        {
            if (!_playerRepository.TryGet(conn.connectionId, out var player)) return;

            player.Loaded = true;
            
            if (_clientLoadingTaskCompletionSources.TryGetValue(conn.connectionId, out var taskCompletionSource))
            {
                taskCompletionSource.TrySetResult();
            }
            
            foreach (var kvp in _playerRepository.Players)
            {
                if (!kvp.Value.Loaded)
                    return;
            }

            ClientLoaded?.Invoke(conn.connectionId);
            
            _allClientsLoadedTcs?.TrySetResult();
        }
    }
}