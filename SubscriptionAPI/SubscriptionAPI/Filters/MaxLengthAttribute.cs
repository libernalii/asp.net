using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SubscriptionAPI.Filters
{
    public class MaxLengthAttribute : IActionFilter
    {
        private readonly int _maxChars;

        public MaxLengthAttribute(int maxChars = 200)
        {
            _maxChars = maxChars;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                var content = objectResult.Value.ToString();

                if (content.Length > _maxChars)
                {
                    context.Result = new BadRequestObjectResult(new
                    {
                        error = "Response too long",
                        length = content.Length,
                        limit = _maxChars
                    });
                }
            }            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
