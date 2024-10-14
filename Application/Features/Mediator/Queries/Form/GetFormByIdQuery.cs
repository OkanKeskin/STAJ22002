using MediatR;

namespace Application.Features.Mediator.Queries.Form;

public class GetFormByIdQuery : IRequest<GetFormQueryResult>
{
    public Guid Id { get; set; }

    public GetFormByIdQuery(Guid id)
    {
        Id = id;
    }
}