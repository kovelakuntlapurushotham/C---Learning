using Microsoft.AspNetCore.Mvc.Filters;

namespace UserManagement.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {

            throw new NotImplementedException();
        }
    }
}
