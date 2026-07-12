using System;

namespace SimpleShop.Infrastructure.Repository.Uow;

public interface IUnitOfWork
{
    Task CommitAsync();
}
