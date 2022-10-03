using ScoringRepository.Models;

namespace ScoringRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
public interface IScoringRepositoryInterface
{
    public ActionResult<Boolean> SubmitAttendeesScores(IEnumerable<PlayerScore> scores);
}