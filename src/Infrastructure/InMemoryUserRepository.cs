using Domain.Abstractions;
using Domain.Model;

namespace Infrastructure;

public class InMemoryUserRepository : IUserRepository
{
     private IDictionary<int, User> _users;

    public InMemoryUserRepository(IEnumerable<User> users)
    {
        this._users = users.ToDictionary(p=>p.Id);
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<User>>(_users.Values);
    }

    public Task<User> GetById(int id)
    {
        return Task.FromResult(_users[id]);
    }
}