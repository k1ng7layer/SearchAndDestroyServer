using System;
using Mirror;
using UniRx.Async;

namespace Services.Network
{
    public interface INetworkServerManager
    {
        event Action<int> ClientConnected; 
        void StartSever();
        void StopServer();
        void RegisterMessageHandler<T>(Action<NetworkConnectionToClient, T, int> handler,
            bool requireAuthentication = true) where T : struct, NetworkMessage;
        void SendToAll<T>(T message) where T : struct, NetworkMessage;
        void SendTo<T>(int netId, T message) where T : struct, NetworkMessage;
        UniTaskVoid WaitForClientConnectedAsync();
    }
}