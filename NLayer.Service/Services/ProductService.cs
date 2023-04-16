using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductServis
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork,
                              IProductRepository productRepository,
                              IMapper mapper,
                              IGenericRepository<Product> repository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        
        public async Task<CustomeResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategories()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomeResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
