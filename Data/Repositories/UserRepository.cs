using Data.Context;
using Data.IRepositories;
using Domain.Entities;

namespace Data.Repositories;

public class UserRepository : Repository<User>,IUserRepository
{
    public UserRepository(BankDbContext dbContext) : base(dbContext)
    {
    }
}
