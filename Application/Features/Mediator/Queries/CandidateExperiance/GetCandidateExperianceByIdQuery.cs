using MediatR;

namespace Application.Features.Mediator.Queries.CandidateExperiance;

public class GetCandidateExperianceByIdQuery : IRequest<List<GetCandidateExperianceByIdQueryResult>>
{
    public Guid CandidateId { get; set; }

    public GetCandidateExperianceByIdQuery(Guid candidateId)
    {
        CandidateId = candidateId;
    }
}