namespace Fantasty_Football_API.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] TeamId { get; set; }
        public string NflTeam { get; set; }
        public Position.Positions Position { get; set; }

    }
}
