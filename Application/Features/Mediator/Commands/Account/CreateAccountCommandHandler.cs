using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Commands.Account;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IRepository<Accounts> _repository;

    public CreateAccountCommandHandler(IRepository<Accounts> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var allAcc = await _repository.GetByFilterListAsync(x => x.Email == request.Email);
        if (allAcc.Count > 0)
        {
            throw new Exception("Aynı mail ile kayıt var");
        }

        var acc = new Accounts
        {
            Email = request.Email,
            Password = request.Password,
            Type = request.Type
        };
        await _repository.CreateAsync(acc);
        return acc.Id;
    }
}