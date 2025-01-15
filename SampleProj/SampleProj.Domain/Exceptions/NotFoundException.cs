using SampleProj.Domain.Enums;

namespace SampleProj.Domain.Exceptions
{
    public class NotFoundException(string message) : BusinessException(ExceptionType.NotFound, message)
    {
        private readonly string _message = message;

        public override string Message => _message;
    }
}
