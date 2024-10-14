using MediatR;

namespace Application.Features.Mediator.Commands.Form;

public class UpdateFormCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Explantion { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime DueTime { get; set; }
    public string Photo { get; set; }
    public string NotBeCandidates { get; set; }
    public string Location { get; set; }
    public string Job { get; set; }
}