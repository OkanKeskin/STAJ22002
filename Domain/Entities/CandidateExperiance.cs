using Domain.Entities.Base;

namespace Domain.Entities;

public class CandidateExperiance : AuditableEntity
{
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Position { get; set; }
    
    public Guid CandidateId { get; set; }
}