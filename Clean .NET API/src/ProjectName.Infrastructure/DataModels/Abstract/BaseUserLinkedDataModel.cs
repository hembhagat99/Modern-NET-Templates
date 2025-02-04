using Microsoft.AspNetCore.Identity;

namespace ProjectName.Infrastructure.DataModels.Abstract
{
    internal abstract class BaseUserLinkedDataModel<TKey> : BaseDataModel<TKey>
    {
        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
