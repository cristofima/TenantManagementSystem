using System;
using System.Text;

namespace EA.TMS.Common.Facade
{
    public static class LoggerHelper
    {
        public static string GetExceptionDetails(Exception ex)
        {
            StringBuilder errorString = new StringBuilder();
            errorString.AppendLine("An error occured. ");
            Exception inner = ex;
            while (inner != null)
            {
                errorString.Append("Error Message:");
                errorString.AppendLine(ex.Message);
                errorString.Append("Stack Trace:");
                errorString.AppendLine(ex.StackTrace);
                inner = inner.InnerException;
            }
            return errorString.ToString();
        }
    }
}