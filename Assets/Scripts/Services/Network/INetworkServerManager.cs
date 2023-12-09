using System;

namespace Services.Network
{
    public interface INetworkServerManager
    {
        event Action<uint> ClientConnected; 
        void StartSever();
        void StopServer();
    }
}