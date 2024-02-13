using System;
using System.IdentityModel.Tokens.Jwt;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatrues;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Presentation.ActionsFilters;
using Services.Contract;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Presentation.Controllers
{

    [ServiceFilter(typeof(LogFilterAttribute))]
	[ApiController]
	[Route("api/product")]
	public class ProductController:ControllerBase
	{
		private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpHead]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters parameters)
        {
            var pagedResult = await _serviceManager
                .productService
                .GetProductsAsync(parameters, false);
            

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(pagedResult.Item2));
            return Ok(pagedResult.Item1);
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
        public async  Task<IActionResult> DeleteProduct([FromRoute(Name = "id")] int id)
        {

            await _serviceManager.productService.DeleteOneProduct(id, false);
            return StatusCode(200);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct([FromBody] ProductDtoForUpdate productDto,[FromRoute(Name ="id")]int id)
        {
            _serviceManager.productService.UpdateOneProduct(id, productDto, false);
            return StatusCode(200, productDto);
        }

        [HttpOptions]
        public IActionResult GetProductOptions()
        {
            Response.Headers.Add("Allow","Get, Post, Put, Delete, Head, Options");
            return Ok();
        }
    }
}

