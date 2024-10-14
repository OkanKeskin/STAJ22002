using MediatR;

namespace Application.Features.Mediator.Commands.Company;

public class UpdateCompanyCommand : IRequest
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Image { get; set; }
}