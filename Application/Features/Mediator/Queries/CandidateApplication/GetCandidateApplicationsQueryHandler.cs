using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.CandidateApplication;

public class GetCandidateApplicationsQueryHandler : IRequestHandler<GetCandidateApplicationsQuery,List<GetCandidateApplicationQueryResult>>
{
    
    private readonly IRepository<Domain.Entities.CandidateApplication> _repository;

    public GetCandidateApplicationsQueryHandler(IRepository<Domain.Entities.CandidateApplication> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetCandidateApplicationQueryResult>> Handle(GetCandidateApplicationsQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByFilterListAsync(a=>a.CandidateId == request.CandidateId);

        return result.Select(x => new GetCandidateApplicationQueryResult
        {
            CandidateId = x.CandidateId,
            FormId = x.FormId,
            Id = x.Id,
            ApplicationStatus = x.ApplicationStatus
        }).ToList();
    }
}