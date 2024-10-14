using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Commands.User;

public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand>
{
    private readonly IRepository<Candidate> _repository;

    public DeleteCandidateCommandHandler(IRepository<Candidate> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}