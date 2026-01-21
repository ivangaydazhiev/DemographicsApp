using Demographics.Domain.Entities;


namespace Demographics.Application.Interfaces
{
    public interface IStatePopulationCalculationService
    {
        Task<List<StatePopulation>> CalculateStatePopulationsAsync(
            CancellationToken cancellationToken = default);
    }
}
