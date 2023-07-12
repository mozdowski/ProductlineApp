using FluentValidation;
using FluentValidation.AspNetCore;
using ProductlineApp.Application;
using ProductlineApp.Infrastructure;
using ProductlineApp.WebUI;
using ProductlineApp.WebUI.Middlewares;
using ProductlineApp.WebUI.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation(s =>
{
    s.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>();
});

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

// app.UseHttpsRedirection();

// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "ClientApp";
//
//     if (app.Environment.IsDevelopment())
//     {
//         spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
//     }
// });

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<UserContextMiddleware>();

app.MapControllers();

app.Run();
