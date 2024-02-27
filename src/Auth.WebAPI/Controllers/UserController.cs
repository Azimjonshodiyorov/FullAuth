using Auth.Application.Interfaces;
using Auth.Domain.Dtos.UserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(this.userService.GetAllAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostUserDto userDto)
        {
            return Ok(await this.userService.CreateUserAsync(userDto)); 
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] long id)
        {
            return Ok(await this.userService.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserDto updateUserDto)
        {
            return Ok(await this.userService.UpdateUserAsync(updateUserDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserDto deleteUserDto)
        {
            return Ok(await this.userService.RemoveUserAsync(deleteUserDto));   
        }




        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] UserCredentials userCredentials)
        {
            return Ok(await this.userService.LoginUserAsync(userCredentials));
        }

                

    }
}
