using MediatR;

namespace Application.Features.Mediator.Commands.CandidateSkill;

public class UpdateCandidateSkillCommand : IRequest
{
    public Guid Id { get; set; }
    public string SkillName { get; set; }
    public string SkillYear { get; set; }
}