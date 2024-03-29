using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers;

[ApiController]
[Route("api")]
public class RootController:ControllerBase
{
    private readonly LinkGenerator _linkGenerator;

    public RootController(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }
    [HttpGet("GetRoot")]
    public async Task<IActionResult> GetRoot([FromHeader(Name = "Accept")]string mediaType)
    {
        if (mediaType.Contains("application/vnd.deneme.apiroot"))
        {
            
        }
        return NoContent();
    }
}