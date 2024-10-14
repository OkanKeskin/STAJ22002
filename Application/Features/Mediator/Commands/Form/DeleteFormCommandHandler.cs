using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediator.Commands.Form;

public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand>
{
    private readonly IRepository<Domain.Entities.Form> _repository;

    public DeleteFormCommandHandler(IRepository<Domain.Entities.Form> repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(DeleteFormCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}