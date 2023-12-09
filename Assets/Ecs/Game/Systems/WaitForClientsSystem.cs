using System;
using Ecs.Game.Extensions;
using JCMG.EntitasRedux;
using Services.Network;

namespace Ecs.Game.Systems
{
    public class WaitForClientsSystem : IInitializeSystem, 
        IDisposable
    {
        private readonly GameContext _game;
        private readonly INetworkServerManager _networkServerManager;

        public WaitForClientsSystem(
            GameContext game, 
            INetworkServerManager networkServerManager
        )
        {
            _game = game;
            _networkServerManager = networkServerManager;
        }
        
        public void Initialize()
        {
            _networkServerManager.ClientConnected += OnClientConnected;
        }
        
        public void Dispose()
        {
            _networkServerManager.ClientConnected -= OnClientConnected;
        }

        private void OnClientConnected(int id)
        {
            _game.CreatePlayer(id);
        }
    }
}