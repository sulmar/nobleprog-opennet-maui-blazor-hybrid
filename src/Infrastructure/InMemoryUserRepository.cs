using Domain.Abstractions;
using Domain.Model;

namespace Infrastructure;

public class InMemoryUserRepository : InMemoryEntityRepository<User>, IUserRepository
{
    public InMemoryUserRepository(IEnumerable<User> items) : base(items)
    {
    }
}
