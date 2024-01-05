using System;
using JCMG.EntitasRedux;
using Mirror;
using Services.ServerManager;
using Utils;

namespace Ecs.Game.Systems
{
    public class ControlSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly IServerStateManager _serverStateManager;
        private readonly GameContext _game;

        public ControlSystem(IServerStateManager serverStateManager, 
            GameContext game)
        {
            _serverStateManager = serverStateManager;
            _game = game;
        }
        
        public void Initialize()
        {
            _serverStateManager.GameStopped += OnGameStopped;
        }
        
        public void Dispose()
        {
            _serverStateManager.GameStopped -= OnGameStopped;
        }

        private void OnGameStopped()
        {
            _game.ReplaceGameState(EGameState.Default);
            
            // var connections = NetworkServer.connections.Values;
            //
            // foreach (var connection in connections)
            // {
            //     NetworkServer.DestroyPlayerForConnection(connection);
            // }
        }
    }
}