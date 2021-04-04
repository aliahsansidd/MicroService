using Microsoft.AspNetCore.Mvc;
using MyFirstMicroService.Models;
using MyFirstMicroService.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product =await _productRepository.GetProductByID(id);
            return new OkObjectResult(product);
        }

        [HttpPost]
        public async Task<Product> Add([FromBody] Product product)
        {
            await _productRepository.CreateProduct(product);
            return product;
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Product product)
        {
            if (product != null)
            {
                await _productRepository.EditProduct(product);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
