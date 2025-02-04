using ProjectName.Domain.Enums;

namespace ProjectName.Domain.Exceptions
{
    public class ForbiddenException : BusinessException
    {
        private readonly string _message;

        public ForbiddenException(string message) : base(ExceptionType.Forbidden, message)
        {
            _message = message;
        }

        public override string Message => _message;
    }
}
