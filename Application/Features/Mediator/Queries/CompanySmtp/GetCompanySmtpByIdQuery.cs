using MediatR;

namespace Application.Features.Mediator.Queries.CompanySmtp;

public class GetCompanySmtpByIdQuery : IRequest<GetCompanySmtpByIdQueryResult>
{
    public Guid CompanyId { get; set; }

    public GetCompanySmtpByIdQuery(Guid companyId)
    {
        CompanyId = companyId;
    }
}