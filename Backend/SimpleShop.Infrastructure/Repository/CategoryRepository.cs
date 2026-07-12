using System;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Models;
using SimpleShop.Infrastructure.Context;
using SimpleShop.Repository.Domain;

namespace SimpleShop.Infrastructure.Repository;

public class CategoryRepository(AppDbContext _context) : IRepository<Category>
{
    public void Add(Category item)
    {
        _context.Add(item);
    }

    public async Task<List<Category>> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
