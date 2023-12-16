using Mirror;

namespace NetworkMessages
{
    public struct PlayerInputMessage : NetworkMessage
    {
        public float X;
        public float Y;
        public float Z;
        public bool Active;
    }
}