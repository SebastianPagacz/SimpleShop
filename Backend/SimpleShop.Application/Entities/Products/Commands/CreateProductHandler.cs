using MediatR;
using SimpleShop.Domain.Models;
using SimpleShop.Repository.Domain;

namespace SimpleShop.Application.Entities.Products.Commands;

public class CreateProductHandler(IRepository<Product> _repository) : IRequestHandler<CreateProductCommand, Result<Product>>
{
    public Task<Result<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productResult = Product.Create(request.Name, request.Price, request.Stock, request.Description);

        if (productResult.IsSuccessful)
            _repository.Add(productResult.Value);

        return Task.FromResult(Result<Product>.Success(productResult.Value));
    }
}
