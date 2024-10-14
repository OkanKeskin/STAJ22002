using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.Form;

public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand,Guid>
{
    private readonly IRepository<Domain.Entities.Form> _repository;

    public UpdateFormCommandHandler(IRepository<Domain.Entities.Form> repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.Explantion = request.Explantion;
        values.Job = request.Job;
        values.Location = request.Location;
        values.Name = request.Name;
        values.Photo = request.Photo;
        values.DueTime = request.DueTime;
        values.StartTime = request.StartTime;
        values.NotBeCandidates = request.NotBeCandidates;
        
        await _repository.UpdateAsync(values);
        return values.Id;
    }
}