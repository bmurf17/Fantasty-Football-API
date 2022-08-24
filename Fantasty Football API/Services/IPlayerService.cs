using Fantasty_Football_API.Models;

namespace Fantasty_Football_API.Services
{
    public interface IPlayerService
    {
        public Task<List<Player>> GetPlayers();
    }
}
