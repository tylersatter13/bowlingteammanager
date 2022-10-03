using Microsoft.AspNetCore.Mvc;
using PlayerRepository.Interfaces;
using PlayerRepository.Models;

namespace PlayerApi.Controllers;
[ApiController]
[Route("[controller]")]
public class PlayerController:ControllerBase
{
   private readonly ILogger<PlayerController> _logger;
   private readonly IPlayerRequestRepository _service;
   public PlayerController(ILogger<PlayerController> logger,  IPlayerRequestRepository service)
   {
      _logger = logger;
      _service = service;
   }
   [HttpPost("Create")]
   public ActionResult<Player> CreatePlayer(Player player)
   {
      return _service.CreatePlayer(player);
   }
   [HttpPatch("Update")]
   public ActionResult<Player> UpdatePlayer(Player player)
   {
      return _service.UpdatePlayer(player);
   }

   [HttpPost( "Delete")]
   public ActionResult<Player> DeletePlayer(Player player)
   {
      return _service.DeletePlayer(player);
   }

   [HttpPatch("GetAll")]
        
   public ActionResult<IEnumerable<Player>> GetAllPlayers(string season)
   {
      return _service.SelectAllPlayers(season);
   }
}