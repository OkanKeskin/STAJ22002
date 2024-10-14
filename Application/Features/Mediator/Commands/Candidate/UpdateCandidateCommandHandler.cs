using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.User;

public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand>
{
    private readonly IRepository<Domain.Entities.Candidate> _repository;
    
    public UpdateCandidateCommandHandler(IRepository<Domain.Entities.Candidate> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.Email = request.Email;
        values.Image = request.Image;
        values.Name = request.Name;
        values.Surname = request.Surname;
        values.PhoneNumber = request.PhoneNumber;
        
        await _repository.UpdateAsync(values);
    }
}