using Auth.Domain.Dtos.ProductDto;
using Auth.Domain.Entities.Products;

namespace Auth.Application.Interfaces
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(PostProductDto product);
        ValueTask<GetProductDto> GetProductByIdAsync(long productId);
        IQueryable<GetProductDto> GetAllProducts();
        ValueTask<Product> UpdateProductAsync(UpdateProductDto product);
        ValueTask<GetProductDto> GetProductNameAsync(string name);
        ValueTask<Product> DeleteProductAsync(long productId);
    }
}
