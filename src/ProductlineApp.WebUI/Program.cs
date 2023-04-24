using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using ProductlineApp.Application;
using ProductlineApp.Infrastructure;
using ProductlineApp.WebUI;
using ProductlineApp.WebUI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddWebUI()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

// Add logging
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
#pragma warning disable S1075 // URIs should not be hardcoded
        spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
#pragma warning restore S1075 // URIs should not be hardcoded
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<UserContextMiddleware>();

app.MapControllers();

app.Run();
