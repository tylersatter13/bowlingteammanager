using Microsoft.AspNetCore.Mvc;
using PracticeRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeServices.Interfaces
{
    public interface IPracticeRequestService
    {
        public ActionResult<IEnumerable<PracticeAttendee>> GetAttendeesByLane(int laneNumber);
        public ActionResult<Practice> CreatePractice(Practice practice);
        public ActionResult<Practice> GetPractice(int practiceId);
        public ActionResult<bool> CheckInPlayer(PracticeAttendee attendee);
        public ActionResult<bool> UpdateCheckedInPlayer(PracticeAttendee attendee);
    }
}
