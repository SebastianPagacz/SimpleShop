namespace SimpleShop.Domain.Models;

public record Result<T> where T : class
{
    public bool IsSuccessful { get; }
    public bool IsFailed => !IsSuccessful;
    public T Value { get; } = null!; 
    public string Message { get; } = string.Empty;

    private Result() {}
    private Result(bool isSuccessful, T value)
    {
        IsSuccessful = isSuccessful;
        Value = value;
    }
    private Result(bool isSuccessful, string message)
    {
        IsSuccessful = isSuccessful;
        Message = message;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value);
    }

    public static Result<T> Fail(string message)
    {
        return new Result<T>(false, message);
    }
}