using System.Collections.Generic;
using Models;

namespace Services.PlayerRepository.Impl
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Dictionary<int, Player> _playersTable = new();

        public IReadOnlyDictionary<int, Player> Players => _playersTable;

        public void Add(Player player)
        {
            _playersTable.Add(player.ConnectionId, player);
        }

        public bool TryGet(int id, out Player player)
        {
            return _playersTable.TryGetValue(id, out player);
        }
    }
}