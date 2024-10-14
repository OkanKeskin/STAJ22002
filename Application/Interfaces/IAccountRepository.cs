using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAccountRepository : IRepository<Accounts>
{
    Task<List<Accounts>> GetByFilterAsync(Expression<Func<Accounts, bool>> filter);
}