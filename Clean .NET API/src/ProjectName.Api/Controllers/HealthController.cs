using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectName.Api.Controllers
{
    public class HealthController : BaseApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            return Ok("Healthy");
        }
    }
}
