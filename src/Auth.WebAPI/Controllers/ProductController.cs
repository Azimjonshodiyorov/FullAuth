using Auth.Application.Interfaces;
using Auth.Domain.Dtos.ProductDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService )
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostProductDto postProductDto)
        {
            return Ok(await this.productService.AddProductAsync(postProductDto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(this.productService.GetAllProducts());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            return Ok(await this.productService.UpdateProductAsync(updateProductDto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await this.productService.DeleteProductAsync(id));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult>  GetById(long id)
        {
            return Ok(await this.productService.GetProductByIdAsync(id));
        }
        [HttpGet("name")]
        public async Task<IActionResult> GetName(string name)
        {
            return Ok(await this.productService.GetProductNameAsync(name));   
        }






    }
}
