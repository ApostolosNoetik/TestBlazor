using System.Reflection;
using TestBlazor.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register Infrastructure services (including IKafkaProducer)
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("TestBlazor.Application"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDevClient", policy =>
    {
        policy.WithOrigins("https://localhost:7002")
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
