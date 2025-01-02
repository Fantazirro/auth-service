using AuthService.Api.Extensions;
using AuthService.Api.Middleware;
using AuthService.Application.Configurations;
using AuthService.Infrastructure.Configurations;
using AuthService.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions();

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices();
builder.Services.ConfigureInfrastructureServices();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.MapControllers();

app.Run();