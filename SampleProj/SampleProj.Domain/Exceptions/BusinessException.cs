using SampleProj.Domain.Enums;

namespace SampleProj.Domain.Exceptions
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
