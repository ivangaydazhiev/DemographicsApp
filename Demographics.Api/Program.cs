using Demographics.Application.Interfaces;
using Demographics.Application.Services;
using Demographics.Infrastructure.ArcGis;
using Demographics.Infrastructure.Background;
using Demographics.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<IArcGisClient, ArcGisClient>();
builder.Services.AddScoped<IStatePopulationCalculationService, StatePopulationCalculationService>();
builder.Services.AddScoped<IStatePopulationQueryService, StatePopulationQueryService>();
builder.Services.AddScoped<IStatePopulationRepository, StatePopulationRepository>();
builder.Services.AddHostedService<PopulationUpdateBackgroundService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemographicsDbContext>(options =>
    options.UseSqlite("Data Source=demographics.db"));
builder.Services.Configure<HostOptions>(options =>
{
    options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
