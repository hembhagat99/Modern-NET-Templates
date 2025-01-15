using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProj.Api.Filters;

namespace SampleProj.Api.Controllers
{
    [ApiController]
    [Authorize]
    [ValidationTypeFilter]
    [TransactionTypeFilter]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
