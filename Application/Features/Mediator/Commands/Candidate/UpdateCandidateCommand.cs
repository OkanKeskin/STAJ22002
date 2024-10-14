using MediatR;

namespace Application.Features.Mediator.Commands.User;

public class UpdateCandidateCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Image { get; set; }
}