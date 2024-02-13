using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace Presentation.Controllers;


[ApiController]
[Route("api/product")]
public class ProductV2Controller:ControllerBase
{
    private IServiceManager _manager;

    public ProductV2Controller(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _manager.productService.GetProductsAsync(false);

        var v2 = products.Select(p =>
        
            new
            {
                p.Id,
                p.ProductName

            }
        );
        var b = HttpContext.Connection.RemoteIpAddress;
        var a = HttpContext.Connection.LocalIpAddress;
            return Ok(v2);
    }
}