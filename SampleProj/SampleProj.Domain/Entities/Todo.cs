using SampleProj.Domain.Entities.Abstract;

namespace SampleProj.Domain.Entities
{
    public class Todo : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
