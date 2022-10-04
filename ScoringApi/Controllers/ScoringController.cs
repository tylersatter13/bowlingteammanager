using Microsoft.AspNetCore.Mvc;
using ScoringRepository.Models;
using ScoringServices.Interfaces;

namespace ScoringApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoringController : ControllerBase
{
    private readonly ILogger<ScoringController> _logger;
    private readonly IScoringRequestService _service;

    public ScoringController(ILogger<ScoringController> logger, IScoringRequestService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("SubmitScore")]
    public ActionResult<Boolean> SubmitAttendeesScores(IEnumerable<PlayerScore> scores)
    {
        return _service.SubmitAttendeesScores(scores);
    }
}