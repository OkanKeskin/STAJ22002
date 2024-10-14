using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace EBursum.Handler.CommandHandlers.Smtp
{
    public class DeleteCompanySmtpCommandHandler : IRequestHandler<DeleteCompanySmtpCommand, Guid>
    {
        private readonly IRepository<CompanySmtp> _repository;

        public DeleteCompanySmtpCommandHandler(IRepository<CompanySmtp> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteCompanySmtpCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByFilterAsync(i => i.CompanyId == request.CompanyId);

            _repository.RemoveAsync(item);

            return item.Id;
        }
    }
}
