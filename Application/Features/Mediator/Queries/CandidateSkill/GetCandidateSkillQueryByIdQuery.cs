using MediatR;

namespace Application.Features.Mediator.Queries.GetCandidateQueryByIdQuery;

public class GetCandidateSkillQueryByIdQuery : IRequest<List<GetCandidateSkillQueryByIdQueryResult>>
{
    public Guid CandidateId { get; set; }

    public GetCandidateSkillQueryByIdQuery(Guid candidateId)
    {
        CandidateId = candidateId;
    }
}