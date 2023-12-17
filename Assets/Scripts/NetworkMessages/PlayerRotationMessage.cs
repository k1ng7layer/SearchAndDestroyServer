using Mirror;

namespace NetworkMessages
{
    public struct PlayerRotationMessage : NetworkMessage
    {
        public float YEuler;
    }
}