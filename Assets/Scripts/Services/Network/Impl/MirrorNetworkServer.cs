using System;
using Mirror;
using UnityEngine;

namespace Services.Network.Impl
{
    public class MirrorNetworkServer : NetworkManager, 
        INetworkServerManager
    {
        public string ServerIp { get; private set; }

        public event Action<uint> ClientConnected; 

        public override void OnServerConnect(NetworkConnectionToClient conn)
        {
            Debug.Log($"OnServerConnect {conn.address}");
            
            ClientConnected?.Invoke(conn.identity.netId);
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