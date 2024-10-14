using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.CandidateExperiance;

public class GetCandidateExperianceByIdQueryHandler : IRequestHandler<GetCandidateExperianceByIdQuery,List<GetCandidateExperianceByIdQueryResult>>
{
    private readonly IRepository<Domain.Entities.CandidateExperiance> _repository;
    
    public GetCandidateExperianceByIdQueryHandler(IRepository<Domain.Entities.CandidateExperiance> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<GetCandidateExperianceByIdQueryResult>> Handle(GetCandidateExperianceByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilterListAsync(c=>c.CandidateId == request.CandidateId);

        return result.Select(x => new GetCandidateExperianceByIdQueryResult()
        {
            Id = x.Id,
            Position = x.Position,
            CompanyName = x.CompanyName,
            DueDate = x.DueDate,
            StartDate = x.StartDate
        }).ToList();
    }
}