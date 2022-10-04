using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoringRepository.Interfaces;
using ScoringRepository.Models;
using ScoringServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoringServices.Services
{
    public class ScoringRequestService:IScoringRequestService
    {
        private readonly IScoringRequestRepository _repository;
        private readonly ILogger<ScoringRequestService> _logger;

        public ScoringRequestService(IScoringRequestRepository repository, ILogger<ScoringRequestService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ActionResult<bool> SubmitAttendeesScores(IEnumerable<PlayerScore> scores)
        {
          return _repository.SubmitAttendeesScores(scores);
        }
    }
}
