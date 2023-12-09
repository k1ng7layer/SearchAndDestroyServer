using Mirror;
using UnityEngine;

namespace Services.Network.Impl
{
    public class MirrorNetworkServer : NetworkManager, 
        INetworkServerManager
    {
        public string ServerIp { get; private set; }

        public override void OnServerConnect(NetworkConnectionToClient conn)
        {
            Debug.Log($"OnServerConnect {conn.address}");
            
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