using Microsoft.VisualBasic;

namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Billing_System.Utilities.ValidationConstants.ValidationConstants.Clients;


    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(FullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        public DateTime ActivationDate { get; set; }

        [Required]
        public DateTime ExpiredDate { get; set; }

        [MaxLength(AddressMaxLength)]
        public string? Comments { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        [Required]
        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public  virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
