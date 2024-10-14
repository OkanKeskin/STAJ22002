using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.Form;

public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand,Guid>
{
    private readonly IRepository<Domain.Entities.Form> _repository;

    public CreateFormCommandHandler(IRepository<Domain.Entities.Form> repository)
    {
        _repository = repository;
    }
    
    public async Task<Guid> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        var form = new Domain.Entities.Form
        {
            CompanyId = request.CompanyId,
            Explantion = request.Explantion,
            Job = request.Job,
            Location = request.Location,
            Name = request.Name,
            Photo = request.Photo,
            DueTime = request.DueTime,
            StartTime = request.StartTime,
            NotBeCandidates = request.NotBeCandidates,
        };
        
        await _repository.CreateAsync(form);

        return form.Id;
    }
}