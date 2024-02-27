using Auth.Application.Interfaces;
using Auth.Domain.Dtos.RoleDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService )
        {
            this.roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostRoleDto postRoleDto)
        {
            return Ok(await this.roleService.AddRoleAsync(postRoleDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRoleDto updateRoleDto)
        {
            return Ok(await this.roleService.UpdateRoleAsync(updateRoleDto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this.roleService.GetAllRoles());
        }

        [HttpGet("/Id")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await this.roleService.GetRoleByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteRoleDto deleteRoleDto)
        {
            return Ok(await this.roleService.DeleteRoleAsync(deleteRoleDto.Id));
        }
    }
}
