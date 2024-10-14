using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.Company;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
{
    private readonly IRepository<Domain.Entities.Company> _repository;

    public CreateCompanyCommandHandler(IRepository<Domain.Entities.Company> repository)
    {
        _repository = repository;
    }
    public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var com = new Domain.Entities.Company
        {
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            CompanyName = request.CompanyName,
            AccountsId = request.AccountsId,
            Image = null
        };
        await _repository.CreateAsync(com);
        return com.Id;
    }
}