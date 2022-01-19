using InficareTask.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace InficareTask.Controllers
{   
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenManager tokenManager;
        private readonly UserInitializer _user;

        public AuthenticateController(ITokenManager tokenManager, UserInitializer user)
        {
            this.tokenManager = tokenManager;
            _user = user;
        }
        [HttpPost]
        public IActionResult Register(string user,string pwd)
        {
            try
            {
                _user.CreateUser(user,pwd);
                return Ok();
            }
            catch (System.Exception ex)
            {
                throw new ArgumentException("Cannot Register:",ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Authenticate(string user,string pwd)
        {
            if(tokenManager.Authenticate(user,pwd))
            {
                return Ok(new { Token = tokenManager.NewToken() });

            }
            else
            {
                ModelState.AddModelError("Unauthorized", "You are not authorized");
                return Unauthorized(ModelState);
            }
        }
    }
}
