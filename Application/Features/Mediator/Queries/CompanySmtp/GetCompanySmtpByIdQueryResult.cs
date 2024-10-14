namespace Application.Features.Mediator.Queries.CompanySmtp;

public class GetCompanySmtpByIdQueryResult
{
    public Guid CompanySmtpId { get; set; }
    public Guid CompanyId { get; set; }
    public string Email { get; set; }
    public string Name { get; set;}
    public string Password { get; set;}
    public string ServerAdress { get; set; }
    public string Port {  get; set; }
}