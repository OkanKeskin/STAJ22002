using MediatR;

namespace EBursum.Handler.CommandHandlers.Smtp
{
    public class UpdateCompanySmtpCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ServerAdress { get; set; }
        public string Port { get; set; }
        public Guid CompanyId { get; set; }
    }
}
