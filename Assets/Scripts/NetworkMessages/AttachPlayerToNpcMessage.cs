using Mirror;

namespace NetworkMessages
{
    public struct AttachPlayerToNpcMessage : NetworkMessage
    {
        public uint PlayerId;
        public uint NpcNetId;
    }
}