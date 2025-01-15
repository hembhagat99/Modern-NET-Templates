namespace SampleProj.Api.DTOs.Error
{
    public class ValidationErrorDto
    {
        public string Field { get; set; }

        public string Message { get; set; }

        public ValidationErrorDto(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
