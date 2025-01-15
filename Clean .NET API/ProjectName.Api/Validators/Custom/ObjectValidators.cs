using FluentValidation;

namespace ProjectName.Api.Validators.Custom
{
    public static class ObjectValidators
    {
        public static IRuleBuilder<T, TElement> Required<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
