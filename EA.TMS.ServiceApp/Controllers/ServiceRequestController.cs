using EA.TMS.Business.Managers.ServiceRequestManagement;
using EA.TMS.Common.BusinessObjects;
using EA.TMS.Common.Entities;
using EA.TMS.ServiceApp.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EA.TMS.ServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [LoggingActionFilter]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ServiceRequestController : BaseController
    {
        private IServiceRequestManager _manager;
        private ILogger<ServiceRequestController> _logger;

        public ServiceRequestController(IServiceRequestManager manager, ILogger<ServiceRequestController> logger) : base(manager, logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TenantServiceRequest> GetTenantsRequests()
        {
            return _manager.GetAllTenantServiceRequests();
        }

        [HttpPost]
        public void Post(ServiceRequest serviceRequest)
        {
            try
            {
                _manager.Create(serviceRequest);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}