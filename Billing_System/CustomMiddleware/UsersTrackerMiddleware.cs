namespace Billing_System.CustomMiddlewares
{
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

                string logMessage = $"{DateTime.Now} - {context.Request.Method} {context.Request.Path}{context.Request.QueryString.Value}" 
                    + Environment.NewLine;

                string username = context.User.Identity.Name;

                string ipaddress = context.Connection.RemoteIpAddress.ToString();

                string userAgent = context.Request.Headers["User-Agent"].ToString();

                string replyUrl = context.Response.StatusCode.ToString();

                string log = $"{username} - {logMessage} - {ipaddress} - {userAgent}{Environment.NewLine}" +
                    $"{replyUrl}{Environment.NewLine}";

                await File.AppendAllTextAsync(filePath, log);
            }

            await next(context);
        }

    }
}
