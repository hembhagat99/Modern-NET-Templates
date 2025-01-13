using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectName.Api.DTOs.Error;

namespace ProjectName.Api.Filters
{
    internal class ValidationFilter(IServiceProvider serviceProvider) : ActionFilterAttribute
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var bodyParameterValue = GetBodyParameterValue(context);
            if (bodyParameterValue == null)
            {
                await next();
            }
            else
            {
                var validationErrors = await ValidateAsync(bodyParameterValue);
                if (validationErrors.Count != 0)
                {
                    context.Result = new BadRequestObjectResult(validationErrors);
                }
                else
                {
                    await next();
                }
            }
        }

        private async Task<List<ValidationErrorDto>> ValidateAsync(object parameter)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(parameter.GetType());
            var validateAsyncMethod = validatorType.GetMethod("ValidateAsync");

            var validator = _serviceProvider.GetService(validatorType);

            if (validator == null || validateAsyncMethod == null)
                return [];

            var task = (Task<ValidationResult>)validateAsyncMethod.Invoke(
                validator,
                new object[]
                {
                    parameter,
                    (CancellationToken)default 
                });
            var validationResult = await task;

            return validationResult.Errors
                .Select(error => new ValidationErrorDto(error.PropertyName, error.ErrorMessage))
                .ToList();
        }

        private object? GetBodyParameterValue(ActionExecutingContext context)
        {
            var bodyParameter = context.ActionDescriptor.Parameters
                .FirstOrDefault(IsBodyParameter);

            if (bodyParameter == null)
                return null;

            return context.ActionArguments.TryGetValue(bodyParameter.Name, out var value)
                ? value
                : null;
        }

        private bool IsBodyParameter(ParameterDescriptor parameter)
        {
            var bindingSource = parameter.BindingInfo?.BindingSource;
            return bindingSource != null && bindingSource.IsFromRequest && bindingSource.Id.Equals("Body", StringComparison.OrdinalIgnoreCase);
        }
    }

    internal class ValidationTypeFilter : TypeFilterAttribute
    {
        public ValidationTypeFilter(): base(typeof(ValidationFilter))
        {
        }
    }
}
