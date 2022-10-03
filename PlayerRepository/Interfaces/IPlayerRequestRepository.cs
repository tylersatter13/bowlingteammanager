using PlayerRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace PlayerRepository.Interfaces
{

    public interface IPlayerRequestRepository
    {
        public ActionResult<Player> CreatePlayer(Player newPlayer);
        public ActionResult<Player> UpdatePlayer(Player player);
        public ActionResult<Player> DeletePlayer(Player player);
        public ActionResult<IEnumerable<Player>> SelectAllPlayers(string season);
    }
}