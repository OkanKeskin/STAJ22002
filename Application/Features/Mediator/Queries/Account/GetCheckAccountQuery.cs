using MediatR;

namespace Application.Features.Mediator.Queries;

public class GetCheckAccountQuery : IRequest<GetCheckAccountQueryResults>
{
    public string Email { get; set; }
    public string Password { get; set; }
}