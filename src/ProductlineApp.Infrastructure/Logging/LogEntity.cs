namespace ProductlineApp.Infrastructure.Logging;

public class LogEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Message { get; set; }

    public LogSeverity Severity { get; set; }

    public Guid UserId { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

public enum LogSeverity
{
        INFO,
        ERROR,
        WARNING,
}
