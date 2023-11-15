using Domain.Abstractions;
using Domain.Model;

namespace Infrastructure;

public class InMemoryEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{
    protected readonly IDictionary<int, T> _items;

    public InMemoryEntityRepository(IEnumerable<T> items)
    {
        this._items = items.ToDictionary(p => p.Id);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<T>>(_items.Values);
    }

    public Task<T> GetById(int id)
    {
        return Task.FromResult(_items[id]);
    }
}