using System;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/product")]
	public class ProductController:ControllerBase
	{
		private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {

            return Ok(_serviceManager.productService.GetProducts(false));
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute(Name = "id")] int id)
        {
            return Ok(_serviceManager.productService.GetOneProductById(id, false));
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _serviceManager.productService.CreateOneProduct(product);
            return StatusCode(201, product);
        }
        [HttpDelete("{id:int}")]
        public IActionResult UpdateProduct([FromRoute(Name = "id")] int id)
        {

            _serviceManager.productService.DeleteOneProduct(id, false);
            return StatusCode(200);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct([FromBody] ProductDtoForUpdate productDto,[FromRoute(Name ="id")]int id)
        {
            if (productDto is null) return BadRequest();
            _serviceManager.productService.UpdateOneProduct(id, productDto, false);
            return StatusCode(200, productDto);
        }
    }
}

