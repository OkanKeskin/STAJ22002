using MediatR;

namespace Application.Features.Mediator.Commands.CandidateExperiance;

public class UpdateCandidateExperianceCommand : IRequest
{
    public Guid Id { get; set; }
    
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Position { get; set; }
}