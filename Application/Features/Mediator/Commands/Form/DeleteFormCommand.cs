using MediatR;

namespace Application.Features.Mediator.Commands.Form;

public class DeleteFormCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteFormCommand(Guid id)
    {
        Id = id;
    }
}