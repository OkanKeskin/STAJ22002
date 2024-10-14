using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Base;

public interface IAuditableEntity<T> where T: IEquatable<T>
{
    [Key] T Id { get; set; }
    Guid CreatedBy { get; set; }
    Guid UpdatedBy { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}

public class AuditableEntity : IAuditableEntity<Guid>
{
    protected AuditableEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    public Guid Id { get; set; }

    public Guid CreatedBy { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}