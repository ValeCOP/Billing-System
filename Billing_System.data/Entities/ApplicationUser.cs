namespace Billing_System.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.ApplicationUsers;

    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(UserNameMaxLength)]
        public override string UserName
        {
            get => base.UserName;
            set => base.UserName = value; 
        }

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();


    }
}
