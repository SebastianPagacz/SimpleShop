using SimpleShop.Domain.Models;

namespace SimpleShop.Application.Entities.Products;

public interface IProductQueryService
{
    Task<Product> GetExistingProductByIdAsync(Guid id, CancellationToken cancellationToken);
}
