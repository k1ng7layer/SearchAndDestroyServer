using System;
using Services.SceneLoading;

namespace Services.ServerManager
{
    public interface IServerStateManager
    {
        bool Ready { get; }
        public event Action GameStopped;
        public event Action ServerReady;
        void InitializeServer();
        void ChangeLevel(ELevelName levelName);
        void Pause(bool value);
        void ShutDownServer();
    }
}