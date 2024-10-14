using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.Company;

public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery,GetCompanyByIdQueryResult>
{
    private readonly IRepository<Domain.Entities.Company> _repository;

    public GetCompanyByIdQueryHandler(IRepository<Domain.Entities.Company> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetCompanyByIdQueryResult> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.CompanyId);

        return new GetCompanyByIdQueryResult
        {
            Image = result.Image,
            Email = result.Email,
            CompanyId = result.Id,
            PhoneNumber = result.PhoneNumber,
            CompanyName = result.CompanyName
        };
    }
}