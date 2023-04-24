namespace ProductlineApp.Domain.Common.Abstractions;

public abstract class AuditableEntity
{
    public DateTime? CreatedAt { get; protected init; } = DateTime.UtcNow;

    public string? CreatedBy { get; protected init; } = "system";

    public DateTime? LastModified { get; set; } = DateTime.UtcNow;

    public string? LastModifiedBy { get; set; } = "system";
}
