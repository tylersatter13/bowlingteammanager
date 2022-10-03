using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerRepository.Context;
using PlayerRepository.Interfaces;
using PlayerRepository.Models;

namespace PlayerRepository;

public class PlayerRequestRepository:IPlayerRequestRepository
{
    private readonly PlayerRepositoryContext _dbContext;
    private readonly ILogger<PlayerRequestRepository> _logger;
   
    public PlayerRequestRepository(
        PlayerRepositoryContext dbContext,
        ILogger<PlayerRequestRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public ActionResult<Player> CreatePlayer(Player newPlayer)
    {
        try
        {
            _dbContext.Add(newPlayer);
            _dbContext.SaveChanges();
            return newPlayer;
        }
        catch
        {
            return new BadRequestResult();
        }
 
    }

    public ActionResult<Player> UpdatePlayer(Player updatedPlayer)
    {
        try
        {
          var result =  _dbContext.Players.FirstOrDefault(player => player.PlayerId == updatedPlayer.PlayerId);
          if (result != null)
          {
              result = updatedPlayer;
              _dbContext.SaveChanges();
              return updatedPlayer;
          }
          return new NotFoundResult();
        }
        catch
        {
            return new BadRequestResult();
        }
    }

    public ActionResult<Player> DeletePlayer(Player player)
    {
        var result = _dbContext.Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);
        if (result != null)
        {
            _dbContext.Remove(result);
            _dbContext.SaveChanges();
            return player;
        }
        return new NotFoundResult();
    }

    public ActionResult<IEnumerable<Player>> SelectAllPlayers(string season)
    {
        var result = _dbContext.Players;
        return result;
    }
}