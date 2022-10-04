using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PracticeRepository.Interfaces;
using PracticeRepository.Models;
using PracticeServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeServices.Services
{
    public class PracticeRequestService:IPracticeRequestService
    {
        private readonly IPracticeRequestRepository _repository;
        private readonly ILogger<PracticeRequestService> _logger;
        public PracticeRequestService(IPracticeRequestRepository repository, ILogger<PracticeRequestService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ActionResult<bool> CheckInPlayer(PracticeAttendee attendee)
        {
          return _repository.CheckInPlayer(attendee);
        }

        public ActionResult<Practice> CreatePractice(Practice practice)
        {
           return _repository.CreatePractice(practice);
        }

        public ActionResult<IEnumerable<PracticeAttendee>> GetAttendeesByLane(int laneNumber)
        {
           return _repository.GetAttendeesByLane(laneNumber);
        }

        public ActionResult<Practice> GetPractice(int practiceId)
        {
            return _repository.GetPractice(practiceId);
        }

        public ActionResult<bool> UpdateCheckedInPlayer(PracticeAttendee attendee)
        {
           return _repository.UpdateCheckedInPlayer(attendee);
        }
    }
}
