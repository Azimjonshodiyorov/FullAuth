using Auth.Application.Interfaces;
using Auth.Domain.Dtos.PermissionsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostPermissionDto postPermissionDto)
        {
            return Ok(await this.permissionService.AddPermissionAsync(postPermissionDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePermissionDto updatePermissionDto)
        {
            return Ok(await this.permissionService.UpdatePermissionAsync(updatePermissionDto)); 
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this.permissionService.GetAllPermissions());
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await this.permissionService.GetPermissionByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePermissionDto deletePermissionDto)
        {
            return Ok(await this.permissionService.DeletePermissionAsync(deletePermissionDto.Id));
        }
    }
}
