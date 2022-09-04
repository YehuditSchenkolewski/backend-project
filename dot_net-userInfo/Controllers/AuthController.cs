using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dot_net_userInfo.Models;
using dot_net_userInfo.Handlers;
using dot_net_userInfo.Models.LoginModels;

namespace dot_net_userInfo.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;
        private readonly DBContext _context;

        public AuthController(IJWTAuthenticationManager jwtAuthenticationManager, DBContext context)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _context = context;
        }

        [HttpPost]
        public ActionResult<LoginResponseModel?> Login([FromBody] LoginRequestModel model)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = _context.Users.Where(u => !string.IsNullOrEmpty(u.Email) && u.Email.Equals(model.Email) &&
                                                 !string.IsNullOrEmpty(u.Password) && u.Password.Equals(model.Password))
                                                .FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            var responseModel = _jwtAuthenticationManager.Authenticate(user);
            return responseModel;
        }
    }
}
