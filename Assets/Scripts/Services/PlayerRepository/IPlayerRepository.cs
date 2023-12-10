using System.Collections.Generic;
using Models;

namespace Services.PlayerRepository
{
    public interface IPlayerRepository
    {
        IReadOnlyDictionary<int, Player> Players { get; }
        
        void Add(Player player);
        bool TryGet(int id, out Player player);
    }
}