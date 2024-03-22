using LoggingService;
using NLog;
using NLog.Extensions.Logging;
using SharedLibrary.Interfaces;
using WorkerService;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
builder.Logging.AddNLog();

builder.Services.AddSingleton(typeof(ILogService<>), typeof(LogService<>));
builder.Services.AddSingleton<IWorkerServiceManager, WorkerServiceManager>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
