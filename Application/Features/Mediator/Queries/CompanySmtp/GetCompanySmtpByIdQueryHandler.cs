using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.CompanySmtp;

public class GetCompanySmtpByIdQueryHandler : IRequestHandler<GetCompanySmtpByIdQuery,GetCompanySmtpByIdQueryResult>
{
    private readonly IRepository<Domain.Entities.CompanySmtp> _repository;

    public GetCompanySmtpByIdQueryHandler(IRepository<Domain.Entities.CompanySmtp> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetCompanySmtpByIdQueryResult> Handle(GetCompanySmtpByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilterAsync(c => c.CompanyId == request.CompanyId);

        return new GetCompanySmtpByIdQueryResult
        {
            Email = result.Email,
            CompanyId = result.CompanyId,
            Name = result.Name,
            Password = result.Password,
            Port = result.Port,
            ServerAdress = result.ServerAdress,
            CompanySmtpId = result.Id
        };
    }
}