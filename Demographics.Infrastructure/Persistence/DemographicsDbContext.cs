using Demographics.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Demographics.Infrastructure.Persistence
{
    public class DemographicsDbContext : DbContext
    {
        public DemographicsDbContext(DbContextOptions<DemographicsDbContext> options) 
            : base(options) { }
        

        public DbSet<StatePopulation> StatePopulations => Set<StatePopulation>();
    }
}
