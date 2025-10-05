using FluentValidation;

namespace Application.Common.Validations;

public static class EntityExistenceValidationExtension
{
    public static IRuleBuilderOptions<T, int> MustExist<T>(
        this IRuleBuilder<T, int> ruleBuilder, 
        Func<int, CancellationToken, Task<bool>> existsFunc,
        string entityName = "Entity")
    {
        return ruleBuilder
            .NotEmpty().WithMessage($"{entityName} Id is required")
            .GreaterThan(0).WithMessage($"{entityName} Id must be greater than 0")
            .MustAsync(async (id, cancellationToken) => await existsFunc(id, cancellationToken))
            .WithMessage($"{entityName} does not exist");
    }

    public static IRuleBuilderOptions<T, Guid> MustExist<T>(
        this IRuleBuilder<T, Guid> ruleBuilder,
        Func<Guid, CancellationToken, Task<bool>> existsFunc,
        string entityName = "Entity")
    {
        return ruleBuilder
            .NotEmpty().WithMessage($"{entityName} Id is required")
            .MustAsync(async (id, cancellationToken) => await existsFunc(id, cancellationToken))
            .WithMessage($"{entityName} does not exist");
    }
}
