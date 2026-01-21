using Demographics.Application.ArcGis.Models;


namespace Demographics.Application.Interfaces
{
    public interface IArcGisClient
    {
        Task<List<ArcGisAttributes>> GetCountyDemographicsAsync (
            CancellationToken cancellationToken = default);
    }
}
