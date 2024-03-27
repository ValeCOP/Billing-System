namespace Billing_System.ActionFilters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Text;

    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User.Identity.Name;
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            string message = $"User {user} executing action '{actionName}' in controller '{controllerName}' at {DateTime.Now}";

            var path = Path.Combine(Environment.CurrentDirectory, "log.txt");
            using (var stream = new StreamWriter(path, true))
            {
                stream.WriteLine(message);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var user = context.HttpContext.User.Identity.Name;
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            string message = $"User {user} executed action '{actionName}' in controller '{controllerName}' at {DateTime.Now}";

            var path = Path.Combine(Environment.CurrentDirectory, "log.txt");
            using (var stream = new StreamWriter(path, true))
            {
                stream.WriteLine(message);
            }

        }
    }

}
