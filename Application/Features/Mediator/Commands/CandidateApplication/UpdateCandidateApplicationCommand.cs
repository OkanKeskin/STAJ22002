using Domain.Enums;
using MediatR;

namespace Application.Features.Mediator.Commands.CandidateApplication;

public class UpdateCandidateApplicationCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public ApplicationStatus ApplicationStatus { get; set; }
}