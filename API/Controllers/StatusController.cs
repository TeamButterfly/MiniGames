using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        public StatusController()
        {
        }

        [HttpGet]
        public ActionResult<bool> Get()
        {
            return true;
        }
    }
}
