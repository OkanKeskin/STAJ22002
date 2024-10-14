using MediatR;

namespace Application.Features.Mediator.Commands.CandidateExperiance;

public class CreateCandidateExperianceCommand : IRequest<Guid>
{
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Position { get; set; }
    
    public Guid CandidateId { get; set; }
}