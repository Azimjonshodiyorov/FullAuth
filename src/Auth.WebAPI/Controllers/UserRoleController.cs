using Auth.Application.Interfaces;
using Auth.Application.Services;
using Auth.Domain.Dtos.UserRoleDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            this.userRoleService = userRoleService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostUserRoleDto postUserRoleDto)
        {
            return Ok(await this.userRoleService.AddUserRoleAsync(postUserRoleDto));    
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this.userRoleService.GetAllUserRoles());
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetBuId(long id)
        {
            return Ok(await this.userRoleService.GetUserRoleByIdAsync(id));
        }
        [HttpPut]


        public async Task<IActionResult> Update(UpdateUserRoleDto updateUserRoleDto)
        {
            return Ok(await this.userRoleService.UpdateUserRoleAsync(updateUserRoleDto));   
        }

        [HttpDelete("Id")]
        public async Task<IActionResult>  Delete(long id)
        {
            return Ok(await this.userRoleService.DeleteUserRoleAsync(id));
        }
    }
}
