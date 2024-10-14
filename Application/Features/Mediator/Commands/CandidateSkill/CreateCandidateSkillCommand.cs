using MediatR;

namespace Application.Features.Mediator.Commands.CandidateSkill;

public class CreateCandidateSkillCommand : IRequest<Guid>
{
    public string SkillsName { get; set; }
    public string SkillsYear { get; set; }
    public Guid CandidateId { get; set; }
}