using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScoringRepository.Models;

namespace ScoringRepository.Context;

public class ScoringRepositoryContext:DbContext
{
    public  DbSet<PlayerScore> PlayerScores { get; set; }
    private readonly string _connectionString;

    public ScoringRepositoryContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionString");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}