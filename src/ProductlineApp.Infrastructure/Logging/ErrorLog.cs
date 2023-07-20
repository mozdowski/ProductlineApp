namespace ProductlineApp.Infrastructure.Logging;

public class ErrorLog
{
    public string Message { get; set; }

    public string StackTrace { get; set; }

    public string? InnerException { get; set; }
}
