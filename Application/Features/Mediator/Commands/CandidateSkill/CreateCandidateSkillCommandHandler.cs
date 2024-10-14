using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateSkill;

public class CreateCandidateSkillCommandHandler : IRequestHandler<CreateCandidateSkillCommand,Guid>
{
    private readonly IRepository<Domain.Entities.CandidateSkill> _candidateSkillRepository;

    public CreateCandidateSkillCommandHandler(IRepository<Domain.Entities.CandidateSkill> candidateSkillRepository)
    {
        _candidateSkillRepository = candidateSkillRepository;
    }
    
    public async Task<Guid> Handle(CreateCandidateSkillCommand request, CancellationToken cancellationToken)
    {
        var candidateSkill = new Domain.Entities.CandidateSkill
        {
            CandidateId = request.CandidateId,
            SkillsName = request.SkillsName,
            SkillsYear = request.SkillsYear
        };

        await _candidateSkillRepository.CreateAsync(candidateSkill);

        return candidateSkill.Id;
    }
}