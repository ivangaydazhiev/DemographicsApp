using Demographics.Domain.Entities;



namespace Demographics.Application.Interfaces
{
    public interface IStatePopulationQueryService
    {
        Task <List<StatePopulation>> GetAsync (
            string? stateName,
            CancellationToken cancellationToken = default);
    }
}
