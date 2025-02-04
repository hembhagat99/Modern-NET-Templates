using Microsoft.AspNetCore.Identity;
using ProjectName.Infrastructure.DataModels.Abstract;

namespace ProjectName.Infrastructure.DataModels
{
    internal class TodoDataModel : BaseUserLinkedDataModel<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
