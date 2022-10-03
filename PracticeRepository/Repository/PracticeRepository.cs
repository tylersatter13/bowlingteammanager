using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Logging;
using PracticeRepository.Context;
using PracticeRepository.Interfaces;
using PracticeRepository.Models;

namespace PracticeRepository.Repository;

public class PracticeRepository:IPracticeRepository
{
    
    private readonly PracticeRepositoryContext _dbContext;
    private readonly ILogger<PracticeRepository> _logger;

    public PracticeRepository(PracticeRepositoryContext dbContext, ILogger<PracticeRepository> logger)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    public ActionResult<IEnumerable<PracticeAttendee>> GetAttendeesByLane(int laneNumber)
    {
        try
        {
            var results =  _dbContext.PracticeAttendees.Where(attendees => attendees.LaneAssignment == laneNumber);
            if (results != null)
            {
                return results.ToList();
            }
            return new NotFoundResult();
        }
        catch
        {
            return new BadRequestResult();
        }

    }

    public ActionResult<Practice> CreatePractice(Practice practice)
    {
        try
        {
            _dbContext.Add(practice);
            _dbContext.SaveChanges();
            return practice;
        }
        catch
        {
            return new BadRequestResult();
        }
      
    }

    public ActionResult<Practice> GetPractice(int practiceId)
    {
        try
        {
            var result = _dbContext.Practices.FirstOrDefault(practice => practice.PracticeId == practiceId);

            if (result != null)
            {
                return result;
            }

            return new NotFoundResult();
        }
        catch
        {
            return new BadRequestResult();
        }
    }

    public ActionResult<bool> CheckInPlayer(PracticeAttendee attendee)
    {
        try
        {
            _dbContext.PracticeAttendees.Add(attendee);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public ActionResult<bool> UpdateCheckedInPlayer(PracticeAttendee attendee)
    {
        try
        {
            var result = _dbContext.PracticeAttendees.FirstOrDefault(a =>
                a.PlayerId == attendee.PlayerId && a.PracticeId == attendee.PracticeId);

            if (result != null)
            {
                result = attendee;
                _dbContext.SaveChanges();
            }

            return new NotFoundResult();
        }
        catch
        {
            return new BadRequestResult();
        }
    }
}