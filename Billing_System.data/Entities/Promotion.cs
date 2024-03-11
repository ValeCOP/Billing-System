namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Utilities.ValidationConstants.ValidationConstants.Promotions;
    public class Promotion
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        public int Month { get; set; }
        
        [Required]
        public string ClientFullName { get; set; } = null!;
    }
}
