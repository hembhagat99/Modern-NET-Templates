namespace ProjectName.Api.DTOs.Todo
{
    public class TodoRequestDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
