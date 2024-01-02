using Mirror;

namespace NetworkMessages
{
    public struct DetachPlayerToNpcMessage : NetworkMessage
    {
        public uint PlayerId;
        public uint NpcNetId;
    }
}