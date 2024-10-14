using MediatR;

namespace Application.Features.Mediator.Queries.Form;

public class GetFormByCompanyIdQuery : IRequest<List<GetFormQueryResult>>
{
    public Guid CompanyId { get; set; }

    public GetFormByCompanyIdQuery(Guid companyId)
    {
        CompanyId = companyId;
    }
}