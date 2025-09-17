namespace Application.Common.Results;

public record Result
{
    public bool IsSuccess { get; }
    public List<Error> Errors { get; }

    protected Result(bool isSuccess, List<Error> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static Result Success() => new(true, [Error.None]);
    public static Result Failure(params Error[] errors) => new(false, errors.ToList());
    public static Result Failure(List<Error> errors) => new(false, errors);

    public static implicit operator Result(Error error) => Failure(error);
    public static implicit operator Result(List<Error> errors) => Failure(errors);
}

public record Result<T> : Result
{
    public T? Value { get; }

    protected internal Result(T? value, bool isSuccess, List<Error> errors)
        : base(isSuccess, errors)
    {
        Value = value;
    }

    public static Result<T> Success(T? value) => new(value, true, [Error.None]);
    public new static Result<T> Failure(params Error[] errors) => new(default, false, errors.ToList());
    public new static Result<T> Failure(List<Error> errors) => new(default, false, errors);

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);
    public static implicit operator Result<T>(List<Error> error) => Failure(error);
}
