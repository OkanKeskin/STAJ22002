using MediatR;

namespace Application.Features.Mediator.Queries.Company;

public class GetCompanyByIdQuery : IRequest<GetCompanyByIdQueryResult>
{
    public Guid CompanyId { get; set; }

    public GetCompanyByIdQuery(Guid companyId)
    {
        CompanyId = companyId;
    }
}