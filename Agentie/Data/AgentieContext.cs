using Agentie.Models;
using Microsoft.EntityFrameworkCore;

namespace Agentie.Data
{
    public class AgentieContext : DbContext
    {
        public AgentieContext(DbContextOptions<AgentieContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transportare> Transports { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Transportare>().ToTable("Transport");
            modelBuilder.Entity<Package>().ToTable("Package");
        }

    }
}
