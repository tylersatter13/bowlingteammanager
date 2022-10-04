using Microsoft.AspNetCore.Mvc;
using PracticeRepository.Models;
using PracticeServices.Interfaces;

namespace PracticeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticeController:ControllerBase
    {
        private readonly ILogger<PracticeController> _logger;
        private readonly IPracticeRequestService _service;
        public PracticeController(ILogger<PracticeController> logger, IPracticeRequestService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("AttendeesByLane")]
        public ActionResult<IEnumerable<PracticeAttendee>> GetAttendeesByLane(int laneNumber)
        {
            return _service.GetAttendeesByLane(laneNumber);
        }
        [HttpPost("Practice")]
        public ActionResult<Practice> CreatePractice(Practice practice)
        {
            return _service.CreatePractice(practice);
        }
        [HttpGet("Practice")]
        public ActionResult<Practice> GetPractice(int practiceId)
        {
            return _service.GetPractice(practiceId);
        }
        [HttpPost("CheckIn")]
        public ActionResult<bool> CheckInPlayer(PracticeAttendee attendee)
        {
            return _service.CheckInPlayer(attendee);
        }
        [HttpPatch("UpdateCheckIn")]
        public ActionResult<bool> UpdateCheckedInPlayer(PracticeAttendee attendee)
        {
            return _service.UpdateCheckedInPlayer(attendee);
        }
    }
}
