namespace Billing_System.CustomMiddleware
{
    using Billing_System.Data.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Caching.Memory;

    public class OnlineUsersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;

        public OnlineUsersMiddleware(RequestDelegate next, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.GetUserAsync(context.User);
            if (user != null)
            {
                var userOnline = new UserOnline
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    LastSeen = DateTime.Now
                };
                var userOnlineList = new List<UserOnline>();
                if (_memoryCache.TryGetValue("OnlineUsers", out List<UserOnline> users))
                {
                    userOnlineList = users;
                }
                userOnlineList.Add(userOnline);

                _memoryCache.Set("OnlineUsers", userOnlineList);

                if (userOnlineList.Count > 0)
                {
                    var usersToRemove = userOnlineList.Where(x => x.LastSeen < DateTime.Now.AddSeconds(-30)).ToList();
                    foreach (var userToRemove in usersToRemove)
                    {
                        userOnlineList.Remove(userToRemove);
                    }
                    _memoryCache.Set("OnlineUsers", userOnlineList, new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromSeconds(30)
                    });
                }
            }
            await _next(context);
        }

        public static bool CheckIfUserIsOnline(Guid userId, IMemoryCache memoryCache)
        {
            if (memoryCache.TryGetValue("OnlineUsers", out List<UserOnline> users))
            {
                var user = users.FirstOrDefault(x => x.UserId == userId);
                if (user != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
