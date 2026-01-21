using Demographics.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;



namespace Demographics.Infrastructure.Background
{
    public class PopulationUpdateBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<PopulationUpdateBackgroundService> _logger;

        public PopulationUpdateBackgroundService(
            IServiceScopeFactory scopeFactory, 
            ILogger<PopulationUpdateBackgroundService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Population update started");

                using var scope = _scopeFactory.CreateScope();


                var service = scope.ServiceProvider.GetRequiredService<IStatePopulationCalculationService>();
                var repo = scope.ServiceProvider.GetRequiredService<IStatePopulationRepository>();


                var populations = await service.CalculateStatePopulationsAsync(stoppingToken);
                
                foreach(var item in populations)
                {
                    await repo.UpsertAsync(item, stoppingToken);
                }

                await repo.SaveChangesAsync(stoppingToken);

                _logger.LogInformation("Population update finished");

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
