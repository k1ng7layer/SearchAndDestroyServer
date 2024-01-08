using Mirror;

namespace NetworkMessages
{
    public struct ClientChangeStateMessage : NetworkMessage
    {
        public byte State;
    }
}