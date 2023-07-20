using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using ProductlineApp.Application.Common.Contexts;
using ProductlineApp.Infrastructure.Persistance;

namespace ProductlineApp.Infrastructure.Logging;

public class LoggingRepository : ILoggingRepository
{
    private readonly ProductlineDbContext _dbContext;
    private readonly ICurrentUserContext _currentUserContext;

    public LoggingRepository(
        ProductlineDbContext dbContext,
        ICurrentUserContext currentUserContext)
    {
        this._dbContext = dbContext;
        this._currentUserContext = currentUserContext;
    }

    public async Task LogError(Exception ex)
    {
        string? stackTrace;

        var stackTraceSymbols = new StackTrace(ex, true).GetFrames();

        var stringBuilder = new StringBuilder();
        int maxStackTraceLines = 5;
        int stackTraceLines = 0;
        foreach (var frame in stackTraceSymbols)
        {
            stringBuilder.AppendLine($"File: {frame.GetFileName()}, Method: {frame.GetMethod()}, Line: {frame.GetFileLineNumber()}");
            stackTraceLines++;

            if (stackTraceLines >= maxStackTraceLines)
                break;
        }

        stackTrace = stringBuilder.ToString();

        var errorLog = new ErrorLog
        {
            Message = ex.Message,
            StackTrace = stackTrace,
            InnerException = ex.InnerException?.Message,
        };

        var jsonErrorLog = JsonConvert.SerializeObject(errorLog);

        var logEntry = new LogEntity()
        {
            Message = jsonErrorLog,
            Timestamp = DateTime.UtcNow,
            Severity = LogSeverity.ERROR,
            UserId = this._currentUserContext.UserId.GetValueOrDefault(),
        };

        await this._dbContext.Logs.AddAsync(logEntry);
        await this._dbContext.SaveChangesAsync();
    }
}
