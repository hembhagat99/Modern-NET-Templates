using FluentValidation;
using ProjectName.Api.DTOs.Todo;
using ProjectName.Api.Validators.Custom;

namespace ProjectName.Api.Validators.Password
{
    public class TodoDtoValidator : AbstractValidator<TodoRequestDto>
    {
        public TodoDtoValidator()
        {
            RuleFor(_ => _.Name).Required();
        }
    }
}
