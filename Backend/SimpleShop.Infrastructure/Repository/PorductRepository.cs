using System;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Models;
using SimpleShop.Infrastructure.Context;
using SimpleShop.Repository.Domain;

namespace SimpleShop.Infrastructure.Repository;

public class PorductRepository(AppDbContext _context) : IRepository<Product>
{
    public void Add(Product item)
    {
        _context.Add(item);
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<List<Product>> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}
