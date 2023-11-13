using Domain.Abstractions;
using Domain.Model;

namespace Infrastructure;

public class DbUserRepository : IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
