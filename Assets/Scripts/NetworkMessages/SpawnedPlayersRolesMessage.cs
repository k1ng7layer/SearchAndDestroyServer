using System.Collections.Generic;
using Mirror;

namespace NetworkMessages
{
    public struct SpawnedPlayersRolesMessage : NetworkMessage
    {
        public List<uint> NetIds;
        public List<byte> Roles;
    }
}