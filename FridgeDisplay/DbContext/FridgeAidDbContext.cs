using FridgeDisplay.Models;
using Microsoft.EntityFrameworkCore;


namespace FridgeAid.Api.Data
{
    public class FridgeAidDbContext : DbContext
    {
        public FridgeAidDbContext(DbContextOptions<FridgeAidDbContext> options) : base(options)
        {
        }

        // DbSet'ene tilføjes her, når modelklasserne er lavet
        public DbSet<Measurement> Measurements { get; set; }
    }
}