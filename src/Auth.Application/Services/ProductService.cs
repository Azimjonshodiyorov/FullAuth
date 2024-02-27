using Auth.Application.Interfaces;
using Auth.Application.Validations;
using Auth.Domain.Dtos.ProductDto;
using Auth.Domain.Entities.Products;
using Auth.Infrastructure.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auth.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository , IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async ValueTask<Product> AddProductAsync(PostProductDto product)
        {
            ObjectValidations.ObjectIsNull(product);

            var mappers = this.mapper.Map<Product>(product);

            var result = await this.productRepository.AddAsync(mappers);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public async ValueTask<Product> DeleteProductAsync(long productId)
        {

            var product = await this.productRepository.GetByIdAsync(productId);

            ObjectValidations.ObjectIsNull(product);

            var result = await this.productRepository.RemoveAsync(product);
            await this.unitOfWork.SaveChangesAsync();
            return result;
        }

        public IQueryable<GetProductDto> GetAllProducts()
        {
            var products = this.productRepository.GetAllAsQueryable();
           
            var result = mapper.Map<List<GetProductDto>>(products.ToList());

            return result.AsQueryable();

        }

        public async ValueTask<GetProductDto> GetProductByIdAsync(long productId)
        {
            var product = await this.productRepository.GetByIdAsync(productId);
            ObjectValidations.ObjectIsNull(product);
            var mapp = mapper.Map<GetProductDto>(product);
            return mapp;
        }

        public async ValueTask<GetProductDto> GetProductNameAsync(string name)
        {
            var result = await this.productRepository.GetAllAsQueryable()
                .FirstOrDefaultAsync(x => x.Name == name);
            ObjectValidations.ObjectIsNull(result);

            var mapp = this.mapper.Map<GetProductDto>(result);  

            return mapp;

        }

        public async ValueTask<Product> UpdateProductAsync(UpdateProductDto product)
        {
            ObjectValidations.ObjectIsNull(product);
            var mapp = this.mapper.Map<Product>(product);
            var prod = await this.productRepository.UpdateAsync(mapp);
            await this.unitOfWork.SaveChangesAsync();
            return prod;
        }
    }
}
