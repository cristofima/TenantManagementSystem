using EA.TMS.Business.Core;
using EA.TMS.Business.Managers.ServiceRequestManagement;
using EA.TMS.Business.Managers.TenantManagement;
using EA.TMS.Common.Core;
using EA.TMS.Common.Entities;
using EA.TMS.Common.Facade;
using EA.TMS.DataAccess.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EA.TMS.BusinessLayer.Managers.TenantManagement
{
    public class TenantManager : BusinessManager, ITenantManager
    {
        private IRepository _repository;
        private ILogger<TenantManager> _logger;
        private IUnitOfWork _unitOfWork;
        private IServiceRequestManager _serviceRequestManager;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public TenantManager(IRepository repository, ILogger<TenantManager> logger, IUnitOfWork unitOfWork, IServiceRequestManager serviceRequestManager) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _serviceRequestManager = serviceRequestManager;
        }

        public virtual Tenant GetTenant(long tenantID)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The tenant Id is " + tenantID);
                return _repository.All<Tenant>().Where(i => i.ID == tenantID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());
            _repository.Create<Tenant>(tenant);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Update(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Update<Tenant>(tenant);
            SaveChanges();
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            _logger.LogInformation("Updating record for {0}", this.GetType());
            _repository.Delete<Tenant>(tenant);
            SaveChanges();
            _logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        IEnumerable<BaseEntity> IActionManager.GetAll()
        {
            return _repository.All<Tenant>().ToList<Tenant>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}