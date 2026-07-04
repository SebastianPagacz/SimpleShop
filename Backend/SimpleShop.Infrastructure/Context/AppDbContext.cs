using Microsoft.EntityFrameworkCore;
using SimpleShop.Domain.Models;
using SimpleShop.Infrastructure.Configurations;

namespace SimpleShop.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProductConfiguration());
    }

    public DbSet<Product> Products { get; set; }
}