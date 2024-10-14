using Domain.Enums;

namespace Application.Features.Mediator.Queries;

public class GetCheckAccountQueryResults
{
    public Guid UserID { get; set; }
    public string Email { get; set; }
    public Guid Id { get; set; }
    public AccountsType Type { get; set; }
    public bool IsExist { get; set; }
}