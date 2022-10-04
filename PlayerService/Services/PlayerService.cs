using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerRepository.Interfaces;
using PlayerRepository.Models;
using PlayerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerServices.Services
{
    public class PlayerService:IPlayersService
    {
        private readonly IPlayerRequestRepository _repository;
        private readonly ILogger<PlayerService> _logger;
        public PlayerService(IPlayerRequestRepository repository, ILogger<PlayerService> logger)
        { 
            _repository = repository;
            _logger = logger;
        }

        public ActionResult<Player> CreatePlayer(Player newPlayer)
        {
            return _repository.CreatePlayer(newPlayer);
        }

        public ActionResult<Player> DeletePlayer(Player player)
        {
            return _repository.DeletePlayer(player);
        }

        public ActionResult<IEnumerable<Player>> SelectAllPlayers(string season)
        {
            return _repository.SelectAllPlayers(season);
        }

        public ActionResult<Player> UpdatePlayer(Player player)
        {
            return _repository.UpdatePlayer(player);
        }
    }
}
