using MediatR;

namespace Application.Features.Mediator.Commands.User;

public class DeleteCandidateCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteCandidateCommand(Guid id)
    {
        Id = id;
    }
}