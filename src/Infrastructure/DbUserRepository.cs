using Domain.Abstractions;
using Domain.Model;

namespace Infrastructure;

public class DbUserRepository : IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
