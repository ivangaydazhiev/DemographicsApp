using Demographics.Application.Interfaces;
using Demographics.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Demographics.Application.Services
{
    public class StatePopulationQueryService : IStatePopulationQueryService
    {
        private readonly IStatePopulationRepository _repository;

        public StatePopulationQueryService(IStatePopulationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StatePopulation>> GetAsync(
            string? stateName,
            CancellationToken cancellationToken = default)
        {
            var query = _repository.Query();

            if(!string.IsNullOrWhiteSpace(stateName))
            {
                query = query.Where(x => 
                x.StateName.ToLower() == stateName.ToLower());
            }

            return await query
                .OrderBy(x => x.StateName)
                .ToListAsync(cancellationToken);
        }
    }
}
