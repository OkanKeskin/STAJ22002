using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateExperiance;

public class CreateCandidateExperianceCommandHandler : IRequestHandler<CreateCandidateExperianceCommand,Guid>
{
    private readonly IRepository<Domain.Entities.CandidateExperiance> _repository;
    
    public CreateCandidateExperianceCommandHandler( IRepository<Domain.Entities.CandidateExperiance> repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> Handle(CreateCandidateExperianceCommand request, CancellationToken cancellationToken)
    {
        var candidateExperiance = new Domain.Entities.CandidateExperiance()
        {
            CandidateId = request.CandidateId,
            DueDate = request.DueDate,
            StartDate = request.StartDate,
            CompanyName = request.CompanyName,
            Position = request.Position
        };

        await _repository.CreateAsync(candidateExperiance);

        return candidateExperiance.Id;
    }
}