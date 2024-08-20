using Infrastructure.Shared.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o =>
{
    o.AddPolicy("local", p =>
    {
        p.WithOrigins("http://localhost:4200");
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

var referencedAssemblies = Assembly.GetEntryAssembly()?.GetReferencedAssemblies().Select(Assembly.Load).ToArray() ?? [];
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(referencedAssemblies));

builder.Host.ConfigureOrleansClient();
builder.Host.ConfigureSerilog();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger", "2.0");
});

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseCors("local");
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
