using Auth.Application.Interfaces;
using Auth.Domain.Dtos.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet , AllowAnonymous]
        public async Task<IActionResult> Get()
        {
           var result =   await  this.userService.GetAllAsync();

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(UserDto userDto)
        {
            var result = await this.userService.CreateUserAsync(userDto);
            return Ok(result);
        }

                

    }
}
