using Domain.Entities.Base;

namespace Domain.Entities;

public class CandidateSkill : AuditableEntity
{
    public string SkillsName { get; set; }
    public string SkillsYear { get; set; }
    public Guid CandidateId { get; set; }
}