using System.Linq.Expressions;
using FluentValidation;

namespace SampleProj.Api.Validators.Custom
{
    public static class StringValidators
    {
        private const string VALID_NAME_REGEX = "^[a-zA-Z]+$";
        private const int NAME_MAX_LENGTH = 250;

        public static IRuleBuilder<T, string> ValidName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Matches(VALID_NAME_REGEX).WithMessage("{PropertyName} should only include alphabets")
                .MaximumLength(NAME_MAX_LENGTH).WithMessage("{PropertyName} should be less than 250 characters");
        }

        public static IRuleBuilder<T, string> ValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .EmailAddress().WithMessage("{PropertyName} should be a valid email address");
        }

        public static IRuleBuilder<T, string> NotSameAs<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            Expression<Func<T, string>> expression)
        {
            return ruleBuilder
                .NotEqual(expression).WithMessage("{PropertyName} should be same as {ComparisonProperty}");
        }

        public static IRuleBuilder<T, string> SameAs<T>(
            this IRuleBuilder<T, string> ruleBuilder,
            Expression<Func<T, string>> expression)
        {
            return ruleBuilder
                .Equal(expression).WithMessage("{PropertyName} should be same as {ComparisonProperty}");
        }
    }
}
