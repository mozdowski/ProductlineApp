namespace ProductlineApp.Application.Common.Contexts;

public interface ILoggingRepository
{
    Task LogError(Exception ex);
}
