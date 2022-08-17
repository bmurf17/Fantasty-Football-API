namespace Fantasty_Football_API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Record { get; set; }
        public string Path { get; set; }
        public Player[] Players {get; set; }
    }
}
