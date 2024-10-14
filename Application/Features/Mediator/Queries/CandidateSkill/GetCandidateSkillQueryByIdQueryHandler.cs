using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Queries.GetCandidateQueryByIdQuery;

public class GetCandidateSkillQueryByIdQueryHandler : IRequestHandler<GetCandidateSkillQueryByIdQuery,List<GetCandidateSkillQueryByIdQueryResult>>
{
    private readonly IRepository<CandidateSkill> _repository;
    
    public GetCandidateSkillQueryByIdQueryHandler(IRepository<CandidateSkill> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetCandidateSkillQueryByIdQueryResult>> Handle(GetCandidateSkillQueryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilterListAsync(c=>c.CandidateId == request.CandidateId);

        return result.Select(x => new GetCandidateSkillQueryByIdQueryResult
        {
            Id = x.Id,
            SkillName = x.SkillsName,
            SkillYear = x.SkillsYear
        }).ToList();
    }
}