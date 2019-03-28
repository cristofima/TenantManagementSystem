using EA.TMS.Business.Core;
using EA.TMS.Common.Facade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EA.TMS.ServiceApp.Controllers
{
    public class BaseController : Controller
    {
        private IActionManager _manager;
        private ILogger _logger;

        public BaseController(IActionManager manager, ILogger logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public IActionManager ActionManager { get { return _manager; } }
        public ILogger Logger { get { return _logger; } }

        public Exception LogException(Exception ex)
        {
            string errorMessage = LoggerHelper.GetExceptionDetails(ex);
            _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, errorMessage);
            throw ex;
            /*HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent(errorMessage);
            message.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
            throw new HttpResponseException(message);*/
        }
    }
}