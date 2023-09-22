using AutoMapper;
using MGP.ApiDotNet6.Application.Dtos;
using MGP.ApiDotNet6.Application.Services.Interfaces;
using MGP.ApiDotNet6.Domain.Repositories;

namespace MGP.ApiDotNet6.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<ResultService<ProductDto>> CreateAsync(ProductDto person)
        {
            throw new NotImplementedException();
        }

        public Task<ResultService> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultService<ICollection<ProductDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResultService<ProductDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResultService<ProductDto>> UpdateAsync(ProductDto person)
        {
            throw new NotImplementedException();
        }      
    }
}
