namespace ScoringRepository.Models;

public class LaneScores
{
    public int PracticeId;
    public int LaneNumber;
    public IEnumerable<PlayerScore> Scores;
}