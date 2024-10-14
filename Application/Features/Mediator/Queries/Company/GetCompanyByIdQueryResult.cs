namespace Application.Features.Mediator.Queries.Company;

public class GetCompanyByIdQueryResult
{
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Image { get; set; }
}