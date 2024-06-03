using LearningApp.Application.Services;
using LearningApp.Domain.Models;
using LearningApp.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearningApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Private Variables
        private readonly IAuthService _authService;
        #endregion

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        #region Endpoints

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            try
            {
                var users = await _authService.GetUserssAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<User>> AddUser([FromBody] User userPayload)
        {
            try
            {
                var user = await _authService.AddUser(userPayload);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}
