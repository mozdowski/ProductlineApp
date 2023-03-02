using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using ProductlineApp.Application;
using ProductlineApp.Infrastructure;
using ProductlineApp.WebUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();

builder.Services.AddApplication()
                .AddInfrastructure()
                .AddWebUI();

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

app.MapControllers();

app.Run();
