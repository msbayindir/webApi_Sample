using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.ActionsFilters;

public class ValidationFilterAttribute:ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];
        var param = context
            .ActionArguments
            .SingleOrDefault(a => a.Value.ToString().Contains("Dto")).Value;

        if (param == null)
        {
            context.Result = new BadRequestObjectResult($"Object is Null." +
                                                        $"\nController:'{controller}'\n" +
                                                        $"Action: '{action}'");
            return;
        }

        if (!context.ModelState.IsValid)
        {
            
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }

    }
}