using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlayerRepository.Models;

namespace PlayerRepository.Context
{
    public class PlayerRepositoryContext:DbContext
    {
        public DbSet<Player> Players { get; set; }
        private readonly string _connectionString;
        public PlayerRepositoryContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("ConnectionString");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}