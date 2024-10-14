using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateApplication;

public class DeleteCandidateApplicationCommandHandler : IRequestHandler<DeleteCandidateApplicationCommand>
{
    private readonly IRepository<Domain.Entities.CandidateApplication> _repository;

    public DeleteCandidateApplicationCommandHandler(IRepository<Domain.Entities.CandidateApplication> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCandidateApplicationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}