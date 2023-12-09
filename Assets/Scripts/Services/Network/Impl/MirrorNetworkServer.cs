using System;
using Mirror;
using UniRx.Async;
using UnityEngine;

namespace Services.Network.Impl
{
    public class MirrorNetworkServer : NetworkManager, 
        INetworkServerManager
    {
        public string ServerIp { get; private set; }

        public event Action<int> ClientConnected; 

        public override void OnServerConnect(NetworkConnectionToClient conn)
        {
            Debug.Log($"OnServerConnect {conn.address}");
            
            ClientConnected?.Invoke(conn.connectionId);
        }

        public void RegisterMessageHandler<T>(Action<NetworkConnectionToClient, T, int> handler, bool requireAuthentication = true) where T : struct, 
            NetworkMessage
        {
            NetworkServer.RegisterHandler(handler);
        }

        public void SendToAll<T>(T message) where T: struct, 
            NetworkMessage
        {
            NetworkServer.SendToAll(message);
        }

        public void SendTo<T>(int netId, T message) where T : struct, NetworkMessage
        {
            NetworkServer.connections[netId].Send(message);
        }

        public UniTaskVoid WaitForClientConnectedAsync()
        {
            throw new NotImplementedException();
        }

        void INetworkServerManager.StartSever()
        {
            StartServer();
        }

        void INetworkServerManager.StopServer()
        {
            StopServer();
        }
    }
}