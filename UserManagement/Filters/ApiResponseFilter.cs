using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserManagement.Models;

namespace UserManagement.Filters
{
    public class ApiResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Check if the result is not null and of type `ActionResult`
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                var responseType = objectResult.Value.GetType();

                // Check if the result value is not already an ApiResponse
                if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(ApiResponse<>))
                {
                    return; 
                }

                // Wrap the result in a ApiResponse<T> if it is not
                var apiResponseType = typeof(ApiResponse<>).MakeGenericType(responseType);
                var success = true;
                var message = "Request was successful.";
                var statusCode = 200;
                var d = context.Result as ObjectResult;
                if (d?.StatusCode != 200)
                {
                    message = "Request was unSuccessful";
                }
                var apiResponse = Activator.CreateInstance(apiResponseType, success, message, statusCode, objectResult.Value);
                context.Result = new ObjectResult(apiResponse)
                {

                    StatusCode = 200 
                };
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log the action execution (this happens before the action method is called)
            Console.WriteLine($"Executing action: {context.ActionDescriptor.DisplayName}");

            // You can also log other useful details about the request, for example:
            Console.WriteLine($"Request Method: {context.HttpContext.Request.Method}");
            Console.WriteLine($"Request Path: {context.HttpContext.Request.Path}");

            // If you want to log the parameters being passed to the action method:
            foreach (var arg in context.ActionArguments)
            {
                Console.WriteLine($"Argument: {arg.Key}, Value: {arg.Value}");
            }
        }
    }
}
