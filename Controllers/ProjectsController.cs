using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsApi.Models;
using ProjectsApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ProjectsApi.Controllers
{
    [Authorize]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(IJwtService jwtService, IProjectService projectsService)
        {
            _jwtService = jwtService;
            _projectsService = projectsService;
        }

        #region Fields
        private IJwtService _jwtService;
        private IProjectService _projectsService;
        #endregion

        #region Public Methods
        [HttpGet("info")]
        public IActionResult GetByUserId()
        {
            var isAuthorization = Request.Headers.TryGetValue("Authorization", out var authorization);

            if (!isAuthorization) return Unauthorized();

            var userId = _jwtService.DecodeSecurityToken(authorization);

            if (userId is null) return Unauthorized();

            var project = _projectsService.GetByUserId(userId);
            var model = ProjectModel.ToProjectModel(project);

            return Ok(model);
        }
        #endregion
    }
}
