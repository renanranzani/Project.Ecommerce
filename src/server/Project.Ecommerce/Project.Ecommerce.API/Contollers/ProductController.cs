using Microsoft.AspNetCore.Mvc;
using Project.Ecommerce.Domain.Interfaces;
using Project.Ecommerce.Infrastructure.DTOS.Command;
using System.Threading.Tasks;

namespace Project.Ecommerce.API.Contollers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var (productsCollection, totalCount) = await _productService.GetAllAsync().ConfigureAwait(false);
            if (totalCount > 0)
                return Ok(new { list = productsCollection, totalCount });

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdProducts(int id)
        {
            var (productsCollection, totalCount) = await _productService.GetByIdAsync(id).ConfigureAwait(false);

            if (totalCount > 0)
                return Ok(new { list = productsCollection, totalCount });

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateProducts([FromBody] ProductCommand command)
        {
            var createdReportQuery = await _productService.CreateAsync(command).ConfigureAwait(false);
            return Created($"/{createdReportQuery.Id}", createdReportQuery);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProducts(int id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            return Ok();
        }
    }
}
