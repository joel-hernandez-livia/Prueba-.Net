using Microsoft.AspNetCore.Mvc;
using ProductApi.BLL.DTOs;
using ProductApi.BLL.Interfaces;

namespace ProductApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductRequest request)
        {
            var productId = await _productService.CreateAsync(request);


            return CreatedAtAction(
                nameof(GetById),
                new { id = productId },
                new
                {
                    ProductId = productId
                });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateProductRequest request)
        {
            var result = await _productService.UpdateAsync(id, request);


            if (!result)
            {
                return NotFound(new
                {
                    message = "Producto no encontrado."
                });
            }


            return NoContent();
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //throw new Exception("Test exception middleware");
            var product = await _productService.GetByIdAsync(id);


            if (product == null)
            {
                return NotFound(new
                {
                    message = "Producto no encontrado."
                });
            }


            return Ok(product);
        }
    }
}