using Demographics.Domain.Entities;


namespace Demographics.Application.Interfaces
{
    public interface IStatePopulationRepository
    {

        IQueryable<StatePopulation> Query();
        Task<List<StatePopulation>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<StatePopulation?> GetByStateAsync(string stateName, CancellationToken cancellationToken = default);
        Task UpsertAsync(StatePopulation entity, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);  
    }
}
