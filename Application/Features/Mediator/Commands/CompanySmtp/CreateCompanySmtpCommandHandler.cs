using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace EBursum.Handler.CommandHandlers.Smtp
{
    public class CreateCompanySmtpCommandHandler : IRequestHandler<CreateCompanySmtpCommand, Guid>
    {
        private readonly IRepository<CompanySmtp> _repository;

        public CreateCompanySmtpCommandHandler(IRepository<CompanySmtp> repository) 
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(CreateCompanySmtpCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _repository.GetByFilterAsync(c => c.CompanyId == request.CompanyId);

            if (isExist != null)
                _repository.RemoveAsync(isExist);

            var smtp = new Domain.Entities.CompanySmtp
            {
                CompanyId = request.CompanyId,
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                ServerAdress = request.ServerAdress,
                Port = request.Port,
            };

            await _repository.CreateAsync(smtp);
            return smtp.Id;
        }
    }
}
