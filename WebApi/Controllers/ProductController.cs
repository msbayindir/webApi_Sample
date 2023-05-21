using System;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Repositories.EfCore;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("api/product")]
	public class ProductController:ControllerBase
	{
		private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            this._manager = manager;
        }

   

		[HttpGet]
		public IActionResult GetProducts()
		{
            
			return Ok(_manager.Product.GetProducts(false));
		}
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute(Name ="id")]int id)
        {
            return Ok(_manager.Product.GetOneProductById(id,false));
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product)
        {
            _manager.Product.CreateOneProduct(product);
            _manager.Save();
            return StatusCode(201,product);
        }
    }
}

