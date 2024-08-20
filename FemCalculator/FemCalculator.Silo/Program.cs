using FemCalculator.Domain;
using FemCalculator.Domain.Builders;
using Infrastructure.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IFemStructureBuilder, FemStructureBuilder>();
builder.Services.AddTransient<IFemCalculator, FemCalculator.Domain.FemCalculator>();


builder.Host.ConfigureOrleansSilo();
builder.Host.ConfigureSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();
