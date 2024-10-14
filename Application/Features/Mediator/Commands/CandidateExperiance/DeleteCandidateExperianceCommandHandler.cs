using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateExperiance;

public class DeleteCandidateExperianceCommandHandler : IRequestHandler<DeleteCandidateExperianceCommand>
{
    private readonly IRepository<Domain.Entities.CandidateExperiance> _repository;

    public DeleteCandidateExperianceCommandHandler(IRepository<Domain.Entities.CandidateExperiance> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCandidateExperianceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}