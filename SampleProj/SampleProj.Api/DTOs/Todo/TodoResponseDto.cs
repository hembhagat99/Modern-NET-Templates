using SampleProj.Api.DTOs.Abstract;

namespace SampleProj.Api.DTOs.Todo
{
    public class TodoResponseDto : BaseResponseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
