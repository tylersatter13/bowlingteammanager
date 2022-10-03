namespace PracticeRepository.Models;

public class Practice
{
    public int PracticeId;
    public DateTime PracticeDate;
    public int SeasonId;
    public List<int> Lanes;
    public decimal Cost;
}