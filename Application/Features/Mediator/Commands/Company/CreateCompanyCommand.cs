using MediatR;

namespace Application.Features.Mediator.Commands.Company;

public class CreateCompanyCommand : IRequest<Guid>
{
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Guid AccountsId { get; set; }
}