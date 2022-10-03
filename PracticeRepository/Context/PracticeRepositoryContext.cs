using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PracticeRepository.Models;

namespace PracticeRepository.Context;

public class PracticeRepositoryContext:DbContext
{
    public DbSet<Practice> Practices { get; set; }
    public DbSet<PracticeAttendee> PracticeAttendees { get; set; }
    private readonly string _connectionString;
    
    public PracticeRepositoryContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("ConnectionString");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}