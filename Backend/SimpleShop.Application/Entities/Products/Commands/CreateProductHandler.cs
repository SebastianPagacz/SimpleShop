using MediatR;
using SimpleShop.Domain.Models;
using SimpleShop.Domain.Repository;
using SimpleShop.Repository.Domain;

namespace SimpleShop.Application.Entities.Products.Commands;

public class CreateProductHandler(IRepository<Product> _repository, IUnitOfWork _uow) : IRequestHandler<CreateProductCommand, Result<Product>>
{
    public async Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productResult = Product.Create(request.Name, request.Price, request.Stock, request.Description);

        if (productResult.IsSuccessful)
        {
            _repository.Add(productResult.Value);
            await _uow.CommitAsync(cancellationToken);
        }

        return Result<Product>.Success(productResult.Value);
    }
}
