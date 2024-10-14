using MediatR;

namespace EBursum.Handler.CommandHandlers.Smtp
{
    public class DeleteCompanySmtpCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
    }
}
