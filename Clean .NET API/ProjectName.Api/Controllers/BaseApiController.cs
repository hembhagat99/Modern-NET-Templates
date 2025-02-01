using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Filters;

namespace ProjectName.Api.Controllers
{
    [ApiController]
    [Authorize]
    [ValidationTypeFilter]
    [TransactionTypeFilter]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected string GetUserId()
        {
            return User!.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }
    }
}
