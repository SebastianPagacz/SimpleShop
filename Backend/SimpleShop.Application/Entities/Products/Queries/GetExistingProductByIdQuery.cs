using System;
using MediatR;
using SimpleShop.Domain.Models;

namespace SimpleShop.Application.Entities.Products.Queries;

public record GetExistingProductByIdQuery(Guid Id) : IRequest<Result<Product>> { }
