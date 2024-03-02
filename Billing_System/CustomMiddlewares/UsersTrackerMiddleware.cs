namespace Billing_System.CustomMiddlewares
{
    using Billing_System.Core.CustomExtensions;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;

    public class UsersTrackerMiddleware
    {
        //write in file logged users with date and time
        private readonly RequestDelegate next;
        private readonly string filePath = "loggedUsers.txt";

        public UsersTrackerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                string userId = context.User.GetId()!;
                string username = context.User.Identity.Name;
                string date = DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss");
                string requestPath = context.Request.Path;
                string requestMethod = context.Request.Method;
                string replyUrl = context.Response.StatusCode.ToString();
                string requestQueryString = context.Request.QueryString.Value;
                string requestUrl = $"{requestMethod} - {requestPath} - {requestQueryString}";
                string replyMethod = context.Response.HttpContext.Request.Method;

                string log = $"{date} - {username} - {userId} - {requestUrl} {Environment.NewLine}" +
                    $"{replyUrl}{Environment.NewLine}" +
                    $"{replyMethod}{Environment.NewLine}";

                await File.AppendAllTextAsync(filePath, log);
            }

            await next(context);
        }

    }
}
