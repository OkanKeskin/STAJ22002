using Domain.Entities.Base;

namespace Domain.Entities;

public class Form : AuditableEntity
{
    public string Name { get; set; }
    public string Explantion { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime DueTime { get; set; }
    public string Photo { get; set; }
    public string NotBeCandidates { get; set; }
    public string Location { get; set; }
    public string Job { get; set; }
    
    public Guid CompanyId { get; set; }
}