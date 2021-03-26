using Microsoft.AspNetCore.Mvc;
using ProjectsApi.Models;
using ProjectsApi.Services;

namespace ProjectsApi.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        #region Fields
        private IJwtService _jwtService;
        private IUserService _userService;
        #endregion

        #region Public Methods
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Email, model.Password);

            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });

            var tokenString = _jwtService.GenerateSecurityToken(user.Id);

            return Ok(new
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Team = user.Team,
                JoinedAt = user.JoinedAt,
                Token = tokenString
            });
        }
        #endregion
    }
}
