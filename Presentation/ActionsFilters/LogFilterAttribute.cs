using Entities.LogModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using NLog.Fluent;
using Services.Contract;

namespace Presentation.ActionsFilters;

public class LogFilterAttribute:ActionFilterAttribute
{
    private ILoggerService _LoggerService { get; set; }

    public LogFilterAttribute(ILoggerService loggerService)
    {
        _LoggerService = loggerService;
    }


    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _LoggerService.LogInfo(Log("OnActionExecuting",context.RouteData));
    }

    public string Log(string modelName, RouteData routeData)
    {
        var logDetail = new LogDetails()
        {
            ModelName = modelName,
            Action = routeData.Values["action"],
            Controller = routeData.Values["controller"],
            Id = routeData.Values["ıd"]
        };
        return logDetail.ToString();
    }
}