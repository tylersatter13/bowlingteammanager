using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerRepository.Models;

namespace PlayerServices.Interfaces
{
    public interface IPlayersService
    {
        public ActionResult<Player> CreatePlayer(Player newPlayer);
        public ActionResult<Player> UpdatePlayer(Player player);
        public ActionResult<Player> DeletePlayer(Player player);
        public ActionResult<IEnumerable<Player>> SelectAllPlayers(string season);
    }
}
