using Domain.Abstractions;
using Domain.Model;

namespace Infrastructure;

public class InMemoryCustomerRepository : InMemoryEntityRepository<Customer>, ICustomerRepository
{
    public InMemoryCustomerRepository(IEnumerable<Customer> items) : base(items)
    {
    }
}
