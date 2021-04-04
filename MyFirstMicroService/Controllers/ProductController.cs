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

        /// <summary>
        /// Get all products
        /// </summary>
        /// <response code="200">Returns when operation successfull.</response>
        /// <response code="400">Returns when operation fail.</response>
        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                return new OkObjectResult(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Get single product by id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <response code="200">Returns when operation successfull.</response>
        /// <response code="400">Returns when operation fail.</response>
        [HttpGet("Get/{id}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productRepository.GetProductByID(id);
                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Add Product 
        /// </summary>
        /// <param name="product">Product model</param>
        /// <response code="200">Returns when operation successfull.</response>
        /// <response code="400">Returns when operation fail.</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public async Task<Product> Add([FromBody] Product product)
        {

            try
            {
                await _productRepository.CreateProduct(product);
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Edit Product 
        /// </summary>
        /// <param name="product">Product model</param>
        /// <response code="200">Returns when operation successfull.</response>
        /// <response code="400">Returns when operation fail.</response>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Edit([FromBody] Product product)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _productRepository.EditProduct(product);
                    return new OkResult();
                }
                else
                {
                    return BadRequest("Can not add Produt.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// delete Product 
        /// </summary>
        /// <param name="id">Product model</param>
        /// <response code="200">Returns when operation successfull.</response>
        /// <response code="400">Returns when operation fail.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            
            try
            {
                await _productRepository.DeleteProduct(id);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
