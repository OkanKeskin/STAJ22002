using Domain.Entities.Base;

namespace Domain.Entities;

public class CompanySmtp : AuditableEntity
{
    public Guid CompanyId { get; set; }
    public string Email { get; set; }
    public string Name { get; set;}
    public string Password { get; set;}
    public string ServerAdress { get; set; }
    public string Port {  get; set; }
}