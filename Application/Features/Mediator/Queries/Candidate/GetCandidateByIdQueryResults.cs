namespace Application.Features.Mediator.Queries.Candidate;

public class GetCandidateByIdQueryResults
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Image { get; set; }
}