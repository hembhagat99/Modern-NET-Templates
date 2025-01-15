using Microsoft.AspNetCore.Identity;
using SampleProj.Infrastructure.DataModels.Abstract;

namespace SampleProj.Infrastructure.DataModels
{
    internal class TodoDataModel : BaseDataModel<Guid>
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public IdentityUser User { get; set; }
    }
}
