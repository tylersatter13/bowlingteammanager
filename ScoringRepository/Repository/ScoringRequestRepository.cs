using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoringRepository.Context;
using ScoringRepository.Interfaces;
using ScoringRepository.Models;

namespace ScoringRepository.Repository;

public class ScoringRequestRepository:IScoringRequestRepository
{
    private readonly ScoringRepositoryContext _dbContext;
    private readonly ILogger<ScoringRequestRepository> _logger;
    
    public ScoringRequestRepository(
        ScoringRepositoryContext dbContext,
        ILogger<ScoringRequestRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public ActionResult<bool> SubmitAttendeesScores(IEnumerable<PlayerScore> scores)
    {
         _dbContext.Add(scores);
         _dbContext.SaveChanges();
         return true;
    }
}