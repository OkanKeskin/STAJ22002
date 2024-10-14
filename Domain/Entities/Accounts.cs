using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Accounts : AuditableEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public AccountsType Type { get; set; }
    
    public List<Company> Company { get; set; }
    public List<Candidate> User { get; set; }
}