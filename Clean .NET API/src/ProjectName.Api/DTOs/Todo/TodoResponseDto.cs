using ProjectName.Api.DTOs.Abstract;

namespace ProjectName.Api.DTOs.Todo
{
    public class TodoResponseDto : BaseUserLinkedResponseDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
