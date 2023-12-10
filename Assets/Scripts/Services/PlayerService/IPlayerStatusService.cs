using System;
using Models;

namespace Services.PlayerService
{
    public interface IPlayerStatusService
    {
        public event Action<Player> PlayerReady;
        public event Action<Player> PlayerLoaded;
    }
}