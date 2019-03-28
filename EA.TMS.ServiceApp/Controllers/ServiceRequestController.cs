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
    public class ServiceRequestController : BaseController
    {
        private IServiceRequestManager _manager;
        private ILogger<ServiceRequestController> _logger;

        public ServiceRequestController(IServiceRequestManager manager, ILogger<ServiceRequestController> logger) : base(manager, logger)
        {
            _manager = manager;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TenantServiceRequest> GetTenantsRequests()
        {
            return _manager.GetAllTenantServiceRequests();
        }

        // POST api/values
        [HttpPost]
        public void Post(ServiceRequest serviceRequest)
        {
            try
            {
                _manager.Create(serviceRequest);
            }
            catch (Exception ex)
            {
                throw LogException(ex);
            }
        }
    }
}