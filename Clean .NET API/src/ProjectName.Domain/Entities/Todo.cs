using ProjectName.Domain.Entities.Abstract;

namespace ProjectName.Domain.Entities
{
    public class Todo : BaseUserLinkedEntity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
