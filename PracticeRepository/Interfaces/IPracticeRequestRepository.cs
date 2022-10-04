using PracticeRepository.Models;
using Microsoft.AspNetCore.Mvc;
namespace PracticeRepository.Interfaces;

public interface IPracticeRequestRepository
{
    /// <summary>
    /// Retrieves a list of Players that are practicing on a specific Lane
    /// </summary>
    /// <param name="laneNumber"></param>
    /// <returns></returns>
    public ActionResult<IEnumerable<PracticeAttendee>> GetAttendeesByLane(int laneNumber);
    public ActionResult<Practice> CreatePractice(Practice practice);
    public ActionResult<Practice> GetPractice(int practiceId);
    public ActionResult<bool> CheckInPlayer(PracticeAttendee attendee);
    public ActionResult<bool> UpdateCheckedInPlayer(PracticeAttendee attendee);
    
}