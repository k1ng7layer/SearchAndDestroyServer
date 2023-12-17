using Mirror;

namespace NetworkMessages
{
    public struct ServerGameStateMessage : NetworkMessage
    {
        public byte GameState;
    }
}