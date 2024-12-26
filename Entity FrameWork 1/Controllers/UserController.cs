using Entity_FrameWork_1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_FrameWork_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var x = _userContext.Users.Include(u => u.UserProfile);
            return Ok(x);
        }
    }
}
