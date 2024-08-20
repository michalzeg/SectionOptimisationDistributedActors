using FitnessEvaluator.Domain;
using FitnessEvaluator.Domain.Specifications;
using FitnessEvaluator.Grain;
using Infrastructure.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IFitnessEvaluator, FitnessEvaluator.Domain.FitnessEvaluator>();
builder.Services.AddScoped<ISpecification<FitnessDetails>[]>(_ => [
        new FlangeThicknessGeometrySpecification(),
        new FlangeWebGeometrySpecification(),
        new FlangeWidthGeometrySpecification(),
        new MaxStressLessThanAllowedStressSpecification(),
        new WebGeometrySpecification(),
        ]);

builder.Host.ConfigureOrleansSilo();
builder.Host.ConfigureSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();