using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class CandidateApplication : AuditableEntity
{
    public Guid FormId { get; set; }
    public Guid CandidateId { get; set;}
    public ApplicationStatus ApplicationStatus { get; set; } 
}