using System;

namespace SimpleShop.Domain.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Product> Products { get; } = [];
    
    private Category() { }
    private Category(string name)
    {
        Name = name;
    }

    public static Result<Category> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            return Result<Category>.Fail("Name can't be null or whitespace.");

        return Result<Category>.Success(new Category(name));
    }

    public Result<Category> ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            return Result<Category>.Fail("Name can't be null or whitespace.");

        if (name == Name)
            return Result<Category>.Fail("Name can't be the same");

        Name = name;
        return Result<Category>.Success(this);
    }
}
