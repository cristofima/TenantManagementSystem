using EA.TMS.Common.Facade;
using EA.TMS.ServiceApp.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;

namespace EA.TMS.ServiceApp.Filters
{
    public class LoggingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Log("OnActionExecuting", context.RouteData, context.Controller);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Log("OnActionExecuted", context.RouteData, context.Controller);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Log("OnResultExecuted", context.RouteData, context.Controller);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Log("OnResultExecuting", context.RouteData, context.Controller);
        }

        private void Log(string methodName, RouteData routeData, Object controller)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            BaseController baseController = ((BaseController)controller);
            baseController.Logger.LogInformation(LoggingEvents.ACCESS_METHOD, message);
        }
    }
}