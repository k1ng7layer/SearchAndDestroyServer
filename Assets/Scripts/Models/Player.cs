namespace Models
{
    public class Player
    {
        public bool Loaded;
        public bool Ready { get; set; }
        public int ConnectionId { get; set; }
        
        public Player(int connectionId)
        {
            ConnectionId = connectionId;
        }
    }
}