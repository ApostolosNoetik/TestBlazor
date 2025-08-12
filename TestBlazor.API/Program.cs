//TestBlazor.API/Program.cs

using System.Reflection;
using TestBlazor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register Infrastructure services (including IKafkaProducer)
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register MediatR handlers from Application assembly
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("TestBlazor.Application"))
);

// Configure CORS to allow Blazor client
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDevClient", policy =>
    {
        policy.WithOrigins("https://localhost:7023")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorDevClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
