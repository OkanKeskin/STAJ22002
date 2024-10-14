using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace EBursum.Handler.CommandHandlers.Smtp
{
    public class UpdateCompanySmtpCommandHandler : IRequestHandler<UpdateCompanySmtpCommand, Guid>
    {
        private readonly IRepository<CompanySmtp> _repository;
        public UpdateCompanySmtpCommandHandler(IRepository<CompanySmtp> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(UpdateCompanySmtpCommand request, CancellationToken cancellationToken)
        {
            var smtp = await _repository.GetByFilterAsync(s => s.CompanyId == request.CompanyId);

            smtp.Email = request.Email;
            smtp.Name = request.Name;
            smtp.Password = request.Password;
            smtp.ServerAdress = request.ServerAdress;
            smtp.Port = request.Port;

            _repository.UpdateAsync(smtp);
            
            return smtp.Id;
        }
    }
}
