using GeneticSolver.Domain;
using GeneticSolver.Domain.Factories;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Silo.Adapters;
using Infrastructure.Shared.Executors;
using Infrastructure.Shared.Extensions;
using Infrastructure.Shared.Utils;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IStatelessGrainExecutor, StatelessGrainExecutor>();
builder.Services.AddScoped<IGeneticSolver, GeneticSolver.Domain.GeneticSolver>();
builder.Services.AddScoped<IFitnessFactory, FitnessFactory>();
builder.Services.AddScoped<IGeneticAlgorithmFactory, GeneticAlgorithmFactory>();
builder.Services.AddScoped<ISolverProgressReporterPort, SolverProgressReporterAdapter>();
builder.Services.AddScoped<IFemCalculationsPort, FemCalculatorAdapter>();
builder.Services.AddScoped<IFitnessEvaluationPort, FitnessEvaluationAdapter>();
builder.Services.AddScoped<IGrainIdentity, GrainIdentity>();

builder.Host.ConfigureOrleansSilo();
builder.Host.ConfigureSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();