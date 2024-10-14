using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.CandidateApplication;

public class GetCandidateApplicationByIdQueryHandler : IRequestHandler<GetCandidateApplicationByIdQuery,GetCandidateApplicationQueryResult>
{
    private readonly IRepository<Domain.Entities.CandidateApplication> _repository;

    public GetCandidateApplicationByIdQueryHandler(IRepository<Domain.Entities.CandidateApplication> repository)
    {
        _repository = repository;
    }
    
    public async Task<GetCandidateApplicationQueryResult> Handle(GetCandidateApplicationByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id);

        return new GetCandidateApplicationQueryResult
        {
            CandidateId = result.CandidateId,
            FormId = result.FormId,
            Id = result.Id,
            ApplicationStatus = result.ApplicationStatus
        };
    }
}