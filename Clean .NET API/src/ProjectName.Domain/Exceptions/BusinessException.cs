using ProjectName.Domain.Enums;

namespace ProjectName.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public ExceptionType Type { get; set; }

        public object ExceptionData { get; set; }

        public BusinessException(ExceptionType type, object exceptionData)
        {
            Type = type;
            ExceptionData = exceptionData;
        }
    }
}
