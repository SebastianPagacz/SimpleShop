using System;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Application.Entities.Products;
using SimpleShop.Domain.Models;
using SimpleShop.Infrastructure.Context;

namespace SimpleShop.Infrastructure.Queries;

public class ProductQueryService(AppDbContext _context) : IProductQueryService
{
    public async Task<Product> GetExistingProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AsNoTracking()
            .Where(p => p.Id == id && !p.IsDeleted)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
