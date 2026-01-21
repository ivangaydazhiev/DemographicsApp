using Demographics.Application.Interfaces;
using Demographics.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Demographics.Infrastructure.Persistence
{
    public class StatePopulationRepository : IStatePopulationRepository
    {
        private readonly DemographicsDbContext _contex;

        public StatePopulationRepository(DemographicsDbContext contex)
        {
            _contex = contex;
        }


        public IQueryable<StatePopulation> Query()
        {
            return _contex.StatePopulations.AsQueryable();
        }

        public async Task<List<StatePopulation>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _contex.StatePopulations.ToListAsync(cancellationToken);

        public async Task<StatePopulation> GetByStateAsync(
            string stateName,
            CancellationToken cancellationToken = default)
        {
            return await _contex.StatePopulations
                .FirstOrDefaultAsync(x => x.StateName == stateName, cancellationToken);
        }

        public async Task UpsertAsync(StatePopulation entity, CancellationToken cancellationToken = default)
        {
            var existing = await GetByStateAsync(entity.StateName, cancellationToken);

            if (existing == null)
            {
                await _contex.StatePopulations.AddAsync(entity, cancellationToken);
            } 
            else
            {
                existing.Population = entity.Population;
                existing.LastUpdated = entity.LastUpdated;
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _contex.SaveChangesAsync(cancellationToken);

    }
}
