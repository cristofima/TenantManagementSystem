using EA.TMS.Business.Core;
using EA.TMS.Common.BusinessObjects;
using System.Collections.Generic;

namespace EA.TMS.Business.Managers.ServiceRequestManagement
{
    public interface IServiceRequestManager : IActionManager
    {
        IEnumerable<TenantServiceRequest> GetAllTenantServiceRequests();
    }
}