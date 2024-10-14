using Application.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateApplication;

public class CreateCandidateApplicationCommandHandler : IRequestHandler<CreateCandidateApplicationCommand,Guid>
{
    private readonly IRepository<Domain.Entities.CandidateApplication> _repository;

    public CreateCandidateApplicationCommandHandler(IRepository<Domain.Entities.CandidateApplication> repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> Handle(CreateCandidateApplicationCommand request, CancellationToken cancellationToken)
    {
        var candidateApplication = new Domain.Entities.CandidateApplication
        {
            ApplicationStatus = ApplicationStatus.Değerlendiriliyor,
            CandidateId = request.CandidateId,
            FormId = request.FormId
        };
        
        await _repository.CreateAsync(candidateApplication);

        return candidateApplication.Id;
    }
}