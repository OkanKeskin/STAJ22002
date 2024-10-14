namespace Application.Features.Mediator.Queries.CandidateExperiance;

public class GetCandidateExperianceByIdQueryResult
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Position { get; set; }
}