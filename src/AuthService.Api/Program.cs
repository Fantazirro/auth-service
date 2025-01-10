using AuthService.Api.Extensions;
using AuthService.Api.Middleware;
using AuthService.Api.Services;
using AuthService.Application.Abstractions.Auth;
using AuthService.Application.Configurations;
using AuthService.Infrastructure.Configurations;
using AuthService.Persistence.Configurations;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions();

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureInfrastructureServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IUserIdentifierProvider, UserIdentifierProvider>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.ConfigureHttpLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.MapHealthChecks("health", new()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();