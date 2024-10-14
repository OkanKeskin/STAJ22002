using Domain.Enums;
using MediatR;

namespace Application.Features.Mediator.Commands.Account;

public class CreateAccountCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountsType Type { get; set; }
}