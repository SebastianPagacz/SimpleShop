using SimpleShop.Domain.Repository;
using SimpleShop.Infrastructure.Context;

namespace SimpleShop.Infrastructure.Repository.UoW;

public class UnitOfWork(AppDbContext _context) : IUnitOfWork
{
    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
