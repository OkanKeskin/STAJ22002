using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.Company;

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly IRepository<Domain.Entities.Company> _repository;

    public DeleteCompanyCommandHandler(IRepository<Domain.Entities.Company> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}