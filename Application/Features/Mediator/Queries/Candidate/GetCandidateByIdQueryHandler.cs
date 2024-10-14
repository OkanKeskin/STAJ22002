using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Queries.Candidate;

public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, GetCandidateByIdQueryResults>
{
    private readonly IRepository<Domain.Entities.Candidate> _repository;

    public GetCandidateByIdQueryHandler(IRepository<Domain.Entities.Candidate> repository)
    {
        _repository = repository;
    }

    public async Task<GetCandidateByIdQueryResults> Handle(GetCandidateByIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.CandidateId);

        return new GetCandidateByIdQueryResults
        {
            Image = result.Image,
            Surname = result.Surname,
            Email = result.Email,
            Id = result.Id,
            Name = result.Name,
            PhoneNumber = result.PhoneNumber
        };
    }
}