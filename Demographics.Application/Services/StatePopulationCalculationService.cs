using Demographics.Application.Interfaces;
using Demographics.Domain.Entities;


namespace Demographics.Application.Services
{
    public class StatePopulationCalculationService : IStatePopulationCalculationService
    {
        private readonly IArcGisClient _arcGisClient;

        public StatePopulationCalculationService(IArcGisClient arcGisClient)
        {
            _arcGisClient = arcGisClient;
        }

        public async Task<List<StatePopulation>> CalculateStatePopulationsAsync(
            CancellationToken cancellationToken = default)
        {
            var records = await _arcGisClient.GetCountyDemographicsAsync(cancellationToken);

            var result = records
                .Where(r => !string.IsNullOrWhiteSpace(r.StateName))
                .GroupBy(r => r.StateName)
                .Select(g => new StatePopulation
                {
                    StateName = g.Key,
                    Population = g.Sum(x => x.Population ?? 0),
                    LastUpdated = DateTime.UtcNow
                })
                .ToList();
            
            return result;
        
        }
    }
}
