using Mirror;

namespace NetworkMessages
{
    public struct LevelLoadingMessage : NetworkMessage
    {
        public string LevelName;
    }
}