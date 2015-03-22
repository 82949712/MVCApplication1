using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Infrastrusture.Logging;
using System.Web.Mvc;
using IActionFilter = System.Web.Mvc.IActionFilter;

namespace Infrastrusture.MVC
{
    public class LoggingFilter : IActionFilter //Filter binding in ninject only works with IActionFilter, not working in ActionFilterAttribute
    {
        private readonly ILogger _logger;
        public LoggingFilter(ILogger logger)
        {
            _logger = logger;
        }


        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = string.Format(
                CultureInfo.InvariantCulture,
                "Executing action {0}.{1}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName);
            _logger.Log(message);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = string.Format(
                CultureInfo.InvariantCulture,
                "Executing action {0}.{1}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName);
            _logger.Log(message);
        }
    }
}
