using EA.TMS.Business.Managers.TenantManagement;
using EA.TMS.Common.Entities;
using EA.TMS.Common.Facade;
using EA.TMS.ServiceApp.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EA.TMS.ServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [LoggingActionFilter]
    public class TenantController : BaseController
    {
        private ITenantManager _tenantManager;
        private ILogger _logger;

        public TenantController(ITenantManager manager, ILogger<TenantController> logger) : base(manager, logger)
        {
            _tenantManager = manager;
            _logger = logger;
        }

        // GET: api/values

        [TransactionActionFilter()]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = _tenantManager.GetAll();
                return new OkObjectResult(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult Post(Tenant tenant)
        {
            try
            {
                _tenantManager.Create(tenant);
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpPut]
        public IActionResult Put(Tenant tenant)
        {
            try
            {
                _tenantManager.Update(tenant);
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpDelete]
        public IActionResult Delete(Tenant tenant)
        {
            try
            {
                _tenantManager.Delete(tenant);
                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        public IActionResult Get(long tenantID)
        {
            try
            {
                var tenant = _tenantManager.GetTenant(tenantID);
                if (tenant != null)
                {
                    return new OkObjectResult(_tenantManager.GetTenant(tenantID));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
    }
}