using EA.TMS.ServiceApp.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;

namespace EA.TMS.ServiceApp.Filters
{
    public class TransactionActionFilter : ActionFilterAttribute
    {
        private IDbContextTransaction transaction;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ((BaseController)context.Controller).ActionManager.UnitOfWork.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                ((BaseController)context.Controller).ActionManager.UnitOfWork.RollbackTransaction();
            }
            else
            {
                ((BaseController)context.Controller).ActionManager.UnitOfWork.CommitTransaction();
            }
        }
    }
}