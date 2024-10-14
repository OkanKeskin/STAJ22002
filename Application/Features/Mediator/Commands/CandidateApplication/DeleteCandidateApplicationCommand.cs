using MediatR;

namespace Application.Features.Mediator.Commands.CandidateApplication;

public class DeleteCandidateApplicationCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteCandidateApplicationCommand(Guid id)
    {
        Id = id;
    }
}