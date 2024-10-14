using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateSkill;

public class UpdateCandidateSkillCommandHandler : IRequestHandler<UpdateCandidateSkillCommand>
{
    private readonly IRepository<Domain.Entities.CandidateSkill> _repository;
    
    public UpdateCandidateSkillCommandHandler(IRepository<Domain.Entities.CandidateSkill> repository)
    {
        _repository = repository;
    }
    
    public async  Task Handle(UpdateCandidateSkillCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.SkillsName = request.SkillName;
        values.SkillsYear = request.SkillYear;

        await _repository.UpdateAsync(values);
    }
}