using AutoMapper;
using KingShoppingCart.API.Models;
using KingShoppingCart.Domain.Contracts;
using KingShoppingCart.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KingShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductRequest productRequest)
        {
            var product = await _productService.CreateAsync(_mapper.Map<Product>(productRequest));

            return Ok(product);
        }
    }
}
