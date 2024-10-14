using MediatR;

namespace Application.Features.Mediator.Commands.Company;

public class DeleteCompanyCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteCompanyCommand(Guid id)
    {
        Id = id;
    }
}