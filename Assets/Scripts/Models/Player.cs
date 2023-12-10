namespace Models
{
    public class Player
    {
        public bool Loaded;
        public bool Ready;
        public int ConnectionId;
        
        public Player(int connectionId)
        {
            ConnectionId = connectionId;
        }
    }
}