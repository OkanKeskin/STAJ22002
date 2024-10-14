using MediatR;

namespace Application.Features.Mediator.Queries.Candidate;

public class GetCandidateByIdQuery : IRequest<GetCandidateByIdQueryResults>
{
    public Guid CandidateId { get; set; }

    public GetCandidateByIdQuery(Guid candidateId)
    {
        CandidateId = candidateId;
    }
}