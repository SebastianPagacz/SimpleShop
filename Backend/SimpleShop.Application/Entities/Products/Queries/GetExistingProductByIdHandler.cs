using System;
using MediatR;
using SimpleShop.Domain.Models;

namespace SimpleShop.Application.Entities.Products.Queries;

public class GetExistingProductByIdHandler(IProductQueryService _queryService) : IRequestHandler<GetExistingProductByIdQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetExistingProductByIdQuery request, CancellationToken cancellationToken)
    {
        var existingProduct = await _queryService.GetExistingProductByIdAsync(request.Id, cancellationToken);

        if (existingProduct is null)
            return Result<Product>.Fail($"Product with Id: {request.Id} does not exist.");

        return Result<Product>.Success(existingProduct);
    }
}
