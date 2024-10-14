using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateExperiance;

public class UpdateCandidateExperianceCommandHandler : IRequestHandler<UpdateCandidateExperianceCommand>
{
    private readonly IRepository<Domain.Entities.CandidateExperiance> _repository;

    public UpdateCandidateExperianceCommandHandler(IRepository<Domain.Entities.CandidateExperiance> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateCandidateExperianceCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.Position = request.Position;
        values.CompanyName = request.CompanyName;
        values.StartDate = request.StartDate;
        values.DueDate = request.DueDate;

        await _repository.UpdateAsync(values);
    }
}