using FluentValidation;
using SampleProj.Api.DTOs.Todo;
using SampleProj.Api.Validators.Custom;

namespace SampleProj.Api.Validators.Password
{
    public class TodoDtoValidator : AbstractValidator<TodoRequestDto>
    {
        public TodoDtoValidator()
        {
            RuleFor(_ => _.Name).Required();
        }
    }
}
