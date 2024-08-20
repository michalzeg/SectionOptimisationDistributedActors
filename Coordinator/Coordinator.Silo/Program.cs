using Infrastructure.Shared.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Host.ConfigureOrleansSilo(storageName: Constants.StorageName);
builder.Host.ConfigureSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.MapControllers();

app.Run();