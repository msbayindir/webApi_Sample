using System;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionsFilters;
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
        public async Task<IActionResult> GetProducts()
        {
            
            return Ok(await _serviceManager.productService.GetProductsAsync(false));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute(Name = "id")] int id)
        {
            return Ok(await _serviceManager.productService.GetOneProductByIdAsync(id, false));
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDtoForInsertion product)
        {
         
            await _serviceManager.productService.CreateOneProductAsync(product);
            return StatusCode(201, product);
        }
        [HttpDelete("{id:int}")]
        public IActionResult UpdateProduct([FromRoute(Name = "id")] int id)
        {

            _serviceManager.productService.DeleteOneProduct(id, false);
            return StatusCode(200);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct([FromBody] ProductDtoForUpdate productDto,[FromRoute(Name ="id")]int id)
        {
            _serviceManager.productService.UpdateOneProduct(id, productDto, false);
            return StatusCode(200, productDto);
        }
    }
}

