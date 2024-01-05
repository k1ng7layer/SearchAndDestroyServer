using System;
using Mirror;
using NetworkMessages;
using Services.Network;
using Services.SceneLoading;
using UniRx;
using Utils;

namespace Services.ServerManager.Impl
{
    public class ServerStateManager : IServerStateManager, IDisposable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;
        private readonly INetworkServerManager _networkServerManager;

        public ServerStateManager(
            ISceneLoadingManager sceneLoadingManager, 
            INetworkServerManager networkServerManager
        )
        {
            _sceneLoadingManager = sceneLoadingManager;
            _networkServerManager = networkServerManager;
        }

        public bool Ready { get; private set; }

        public event Action GameStopped;
        public event Action ServerReady;

        public void InitializeServer()
        {
            _sceneLoadingManager.Loaded += OnLoaded;
            _sceneLoadingManager.LoadGameFromSplash();
        }
        
        public void Dispose()
        {
            _sceneLoadingManager.Loaded -= OnLoaded;
        }

        public void ChangeLevel(ELevelName levelName)
        {
            Ready = false;
            
            GameStopped?.Invoke();

            // var connections = NetworkServer.connections.Values;
            //
            // foreach (var connection in connections)
            // {
            //     NetworkServer.DestroyPlayerForConnection(connection);
            // }
            
            _networkServerManager.SendToAll(new ServerGameStateMessage
            {
                GameState = (byte)EGameState.Default
            });
            
            _networkServerManager.SendToAll(new LevelLoadingMessage
            {
                LevelName = ELevelName.CLASSIC.ToString()
            });

            Observable.Timer(TimeSpan.FromMilliseconds(2000)).Subscribe(_ =>
            {
                _sceneLoadingManager.LoadGameLevel(levelName);
            });
            
        }

        public void Pause(bool value)
        {
            
        }

        public void ShutDownServer()
        {
            
        }

        private void OnLoaded()
        {
            Ready = true;
                
            ServerReady?.Invoke();
        }
    }
}