using MediatR;

namespace Application.Features.Mediator.Commands.CandidateSkill;

public class DeleteCandidateSkillCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteCandidateSkillCommand(Guid id)
    {
        Id = id;
    }
}