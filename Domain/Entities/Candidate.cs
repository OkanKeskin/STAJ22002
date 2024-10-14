using Domain.Entities.Base;

namespace Domain.Entities;

public class Candidate : AuditableEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Image { get; set; }
    public Accounts Accounts { get; set; }
    public Guid AccountsId { get; set; }
    
    public List<CandidateSkill> CandidateSkills { get; set; }
    public List<CandidateExperiance> CandidateExperiances { get; set; }
    public List<CandidateApplication> CandidateApplications { get; set; }
}