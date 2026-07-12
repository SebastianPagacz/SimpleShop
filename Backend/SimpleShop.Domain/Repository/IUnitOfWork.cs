using System;

namespace SimpleShop.Domain.Repository;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}
