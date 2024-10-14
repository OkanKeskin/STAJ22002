using MediatR;

namespace Application.Features.Mediator.Queries.CandidateApplication;

public class GetCandidateApplicationByIdQuery : IRequest<GetCandidateApplicationQueryResult>
{
    public Guid Id { get; set; }

    public GetCandidateApplicationByIdQuery(Guid id)
    {
        Id = id;
    }
}