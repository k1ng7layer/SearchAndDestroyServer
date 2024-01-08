using System;
using Models;

namespace Services.PlayerMessageService
{
    public interface IPlayerMessageService
    {
        public event Action<Player> PlayerReady;
        public event Action<Player> PlayerLoaded;
    }
}