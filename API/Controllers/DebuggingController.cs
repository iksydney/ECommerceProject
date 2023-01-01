using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebuggingController : BaseApiController
    {
        public DebuggingController()
        {

        }
        [Authorize]
        [HttpGet("authorize")]
        public ActionResult<string> ReturnString()
        {
            return "Checked token successfully";
        }
    }
}
