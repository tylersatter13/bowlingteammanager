using Microsoft.AspNetCore.Mvc;
using ScoringRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoringServices.Interfaces
{
    public interface IScoringRequestService
    {
        public ActionResult<Boolean> SubmitAttendeesScores(IEnumerable<PlayerScore> scores);
    }
}
