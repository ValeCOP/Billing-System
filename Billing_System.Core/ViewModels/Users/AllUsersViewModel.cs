namespace Billing_System.Core.ViewModels.Users
{
    public class AllUsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
