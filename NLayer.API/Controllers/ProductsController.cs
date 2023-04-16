using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductServis _productServis;

        public ProductsController(IService<Product> service, IMapper mapper, IProductServis productServis)
        {
            _mapper = mapper;
            _service = service;
            _productServis = productServis;
        }
        // [action] : metotun ismini temsil eder
        // GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productServis.GetProductWithCategories());
        }
        //  /api/product
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomeResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        //  /api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomeResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomeResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomeResponseDto<NoContentDto>.Success(204));
        }

        //  /api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomeResponseDto<NoContentDto>.Success(204));
        }
    }
}
