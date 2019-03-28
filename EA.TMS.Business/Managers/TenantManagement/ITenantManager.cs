using EA.TMS.Business.Core;
using EA.TMS.Common.Entities;

namespace EA.TMS.Business.Managers.TenantManagement
{
    public interface ITenantManager : IActionManager
    {
        Tenant GetTenant(long tenantID);
    }
}