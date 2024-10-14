using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateSkill;

public class DeleteCandidateSkillCommandHandler : IRequestHandler<DeleteCandidateSkillCommand>
{
    private readonly IRepository<Domain.Entities.CandidateSkill> _repository;

    public DeleteCandidateSkillCommandHandler(IRepository<Domain.Entities.CandidateSkill> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteCandidateSkillCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}