using Microsoft.AspNetCore.Mvc;

namespace ScoringApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoringController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}