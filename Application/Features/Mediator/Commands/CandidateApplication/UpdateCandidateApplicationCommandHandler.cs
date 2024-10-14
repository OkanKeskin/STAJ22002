using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateApplication;

public class UpdateCandidateApplicationCommandHandler : IRequestHandler<UpdateCandidateApplicationCommand,Guid>
{
    private readonly IRepository<Domain.Entities.CandidateApplication> _repository;

    public UpdateCandidateApplicationCommandHandler(IRepository<Domain.Entities.CandidateApplication> repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> Handle(UpdateCandidateApplicationCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.ApplicationStatus = request.ApplicationStatus;
        
        await _repository.UpdateAsync(values);

        return values.Id;
    }
}