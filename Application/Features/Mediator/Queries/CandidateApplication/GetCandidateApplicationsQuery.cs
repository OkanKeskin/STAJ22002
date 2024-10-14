using Application.Features.Mediator.Queries.Form;
using MediatR;

namespace Application.Features.Mediator.Queries.CandidateApplication;

public class GetCandidateApplicationsQuery : IRequest<List<GetCandidateApplicationQueryResult>>
{
    public Guid CandidateId { get; set; }

    public GetCandidateApplicationsQuery(Guid candidateId)
    {
        CandidateId = candidateId;
    }
}