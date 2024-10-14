using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Queries;

public class GetCheckAccountQueryHandler : IRequestHandler<GetCheckAccountQuery,GetCheckAccountQueryResults>
{
    private readonly IRepository<Accounts> _accountRepository;
    private readonly IRepository<Domain.Entities.Company> _companyRepository;
    private readonly IRepository<Domain.Entities.Candidate> _userRepository;

    public GetCheckAccountQueryHandler(IRepository<Accounts> accountRepository, IRepository<Domain.Entities.Company> companyRepository, IRepository<Domain.Entities.Candidate> userRepository)
    {
        _accountRepository = accountRepository;
        _companyRepository = companyRepository;
        _userRepository = userRepository;
    }

    
    public async Task<GetCheckAccountQueryResults> Handle(GetCheckAccountQuery request, CancellationToken cancellationToken)
    {
        var values = new GetCheckAccountQueryResults();
        var acc = await _accountRepository.GetByFilterAsync(x => x.Email == request.Email && x.Password == request.Password);
            
        if (acc == null)
        {
            values.IsExist = false;
        }
        else
        {
            if(acc.Type == Domain.Enums.AccountsType.Company)
            {
                var company = await _companyRepository.GetByFilterAsync(c => c.Email == acc.Email);
                values.Id = company.Id;
            }
            else if (acc.Type == Domain.Enums.AccountsType.Candidate)
            {
                var customer = await _userRepository.GetByFilterAsync(e => e.Email == acc.Email);
                values.Id = customer.Id;
            }

            values.IsExist = true;
            values.Email = acc.Email;
            values.Type = acc.Type;
            values.UserID = acc.Id;
                
        }
        return values;
    }
}