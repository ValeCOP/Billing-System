namespace Billing_System.CustomMiddlewares
{
    using System.Text;

    public class UsersTrackerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string filePath = "trackUsers.txt";

        public UsersTrackerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {

                string logMessage = $"{DateTime.Now} - {context.Request.Method} {context.Request.Path}{context.Request.QueryString.Value}" 
                    + Environment.NewLine;

                string username = context.User.Identity.Name;

                string ipAddress = context.Connection.RemoteIpAddress.ToString();

                string userAgent = context.Request.Headers["User-Agent"].ToString();

                string replyUrl = context.Response.StatusCode.ToString();

                string log = $"{username} - {logMessage} - {ipAddress} - {userAgent}{Environment.NewLine}" +
                    $"{replyUrl}{Environment.NewLine}";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    await writer.WriteAsync(log);
                }

            }

            await _next(context);
        }
    }
}
