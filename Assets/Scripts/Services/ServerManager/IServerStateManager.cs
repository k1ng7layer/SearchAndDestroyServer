using System;
using Services.SceneLoading;
using UniRx.Async;

namespace Services.ServerManager
{
    public interface IServerStateManager
    {
        bool Ready { get; }
        public event Action GameStopped;
        public event Action ServerReady;
        void InitializeServer();
        UniTask ChangeLevelAsync(ELevelName levelName);
        void SetServerState(EServerState state);
        void Pause(bool value);
        void ShutDownServer();
    }
}