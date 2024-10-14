using MediatR;

namespace Application.Features.Mediator.Commands.CandidateApplication;

public class CreateCandidateApplicationCommand : IRequest<Guid>
{
    public Guid FormId { get; set; }
    public Guid CandidateId { get; set;}
}