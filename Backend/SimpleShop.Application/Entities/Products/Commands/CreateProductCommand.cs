using System;
using MediatR;
using SimpleShop.Domain.Models;

namespace SimpleShop.Application.Entities.Products.Commands;

public record CreateProductCommand(string Name, decimal Price, int Stock, string? Description) : IRequest<Result<Product>> { }
