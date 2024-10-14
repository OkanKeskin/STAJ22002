using System.Linq.Expressions;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories;

public class AccountRepository : Repository<Accounts>, IAccountRepository
{
    public AccountRepository(ProjectContext context) : base(context)
    {
            
    }
    
    public async Task<List<Accounts>> GetByFilterAsync(Expression<Func<Accounts, bool>> filter)
    {
        return await _context.Set<Accounts>().Where(filter).ToListAsync();
    }   
}