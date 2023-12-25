using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Service.IServices;
using UserManagement.Shared.Models.UserDtos;

namespace UserManagement.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(InsertDto model)
        {
            try
            {
                await _userService.InsertUser(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUser model)
        {
            try
            {
                await _userService.UpdateUser(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
