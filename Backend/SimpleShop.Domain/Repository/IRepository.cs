using System;

namespace SimpleShop.Repository.Domain;

public interface IRepository<T> where T : class
{
    void Add(T item);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAsync(CancellationToken cancellationToken);
}
