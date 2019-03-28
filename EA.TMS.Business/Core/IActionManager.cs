using EA.TMS.Common.Core;
using EA.TMS.DataAccess.Core;
using System.Collections.Generic;

namespace EA.TMS.Business.Core
{
    public interface IActionManager
    {
        void Create(BaseEntity entity);

        void Update(BaseEntity entity);

        void Delete(BaseEntity entity);

        IEnumerable<BaseEntity> GetAll();

        IUnitOfWork UnitOfWork { get; }

        void SaveChanges();
    }
}