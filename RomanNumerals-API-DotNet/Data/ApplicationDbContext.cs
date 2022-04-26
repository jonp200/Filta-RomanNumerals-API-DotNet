using Microsoft.EntityFrameworkCore;
using RomanNumerals_API_DotNet.Models;

namespace RomanNumerals_API_DotNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ConversionLog> ConversionLogs { get; set; }
    }
}
