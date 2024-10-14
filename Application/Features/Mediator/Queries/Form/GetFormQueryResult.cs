namespace Application.Features.Mediator.Queries.Form;

public class GetFormQueryResult
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
    
    public Guid CompanyId { get; set; }
}