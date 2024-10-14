using MediatR;

namespace Application.Features.Mediator.Commands.CandidateExperiance;

public class DeleteCandidateExperianceCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteCandidateExperianceCommand(Guid id)
    {
        Id = id;
    }
}