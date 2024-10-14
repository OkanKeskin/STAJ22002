using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.Company;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IRepository<Domain.Entities.Company> _repository;
    
    public UpdateCompanyCommandHandler(IRepository<Domain.Entities.Company> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.Email = request.Email;
        values.Image = request.Image;
        values.PhoneNumber = request.PhoneNumber;
        values.CompanyName = request.CompanyName;
        
        await _repository.UpdateAsync(values);
    }
}