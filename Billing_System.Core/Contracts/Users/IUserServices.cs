namespace Billing_System.Core.Contracts.Users
{
    using Billing_System.Core.ViewModels.Users;
    using Billing_System.Data.Entities;

    public interface IUserServices
    {
        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
        Task RegisterUser(RegisterViewModel model);
        Task DeleteUser(string id);
        Task EditUser(RegisterViewModel model, string id);
        Task<ApplicationUser> GetUserById(string id);
        Task<ICollection<UsersViewWithPayments>> GetAllUserWithPayments();
    }
}
