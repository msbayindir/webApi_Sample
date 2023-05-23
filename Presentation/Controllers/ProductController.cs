using System;
using Entities.Models;
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
    }
}

