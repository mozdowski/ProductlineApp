namespace ProductlineApp.Domain.Common;

public abstract class AuditableEntity
{
    public DateTime? CreatedAt { get; protected init; }

    public string? CreatedBy { get; protected init; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }
}
