namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Utilities.ValidationConstants.ValidationConstants.Chat;

    public class Chat
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(UserMaxLength)]
        public string User { get; set; } = null!;

        [Required]
        [MaxLength(MessageMaxLength)]
        public string Message { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}
