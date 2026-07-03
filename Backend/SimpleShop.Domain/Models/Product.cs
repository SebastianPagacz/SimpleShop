namespace SimpleShop.Domain.Models;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Description { get; private set; }

    private Product() {}
    private Product(string name, decimal price, int stock, string? description)
    {
        Name = name;
        Price = price;
        Stock = stock;
        Description = description;
    }

    public static Result<Product> Create(string name, decimal price, int stock, string? description = default)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            return Result<Product>.Fail("Name can't be null, empty or exceed 255 characters.");

        if (price <= 0)
            return Result<Product>.Fail("Price must be higher than 0.");

        if (stock < 0)
            return Result<Product>.Fail("Stock can't be negative.");

        return Result<Product>.Success(new Product(name, price, stock, description));
    }

    public Result<Product> ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            return Result<Product>.Fail("Name can't be null, empty or exceed 255 characters.");

        Name = name;
        return Result<Product>.Success(this);
    }

    public Result<Product> ChangePrice(decimal price)
    {
        if (price <= 0)
            return Result<Product>.Fail("Price must be higher than 0.");

        Price = price;
        return Result<Product>.Success(this);
    }

    public Result<Product> IncreaseStock(int value)
    {
        if (value <= 0)
            return Result<Product>.Fail("Can't increase stock be 0 or lower value.");
            
        Stock += value;
        return Result<Product>.Success(this);
    }

    public Result<Product> DecreaseStock(int value)
    {
        if (value <= 0)
            return Result<Product>.Fail("Can't decrease stock by 0 or lower.");

        if (value > Stock)
            return Result<Product>.Fail("Not enough in stock.");

        Stock -= value;
        return Result<Product>.Success(this);
    }

    public Result<Product> SetStock(int stock)
    {
        if (stock < 0)
            return Result<Product>.Fail("Stock can't be negative.");

        Stock = stock;
        return Result<Product>.Success(this);
    }

    public Result<Product> ChangeDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return Result<Product>.Fail("Description can't be null or empty.");

        Description = description;
        return Result<Product>.Success(this);
    }

    public Result<Product> DeleteDescription()
    {
        Description = null;
        return Result<Product>.Success(this);
    }
}