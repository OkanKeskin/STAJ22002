using Domain.Entities.Base;

namespace Domain.Entities;

public class Company : AuditableEntity
{
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Image { get; set; }
    public Guid AccountsId { get; set; }
    public Accounts Accounts { get; set; }
    public virtual CompanySmtp CompanySmtp { get; set; }
    public virtual List<Form> Forms { get; set; }
}