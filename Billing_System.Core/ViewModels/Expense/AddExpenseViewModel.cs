namespace Billing_System.Core.ViewModels.Expense
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using static Utilities.ValidationConstants.ValidationConstants.Expense;

    public class AddExpenseViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameErrorMessage)]
        public string Name { get; set; } = null!;
        [Required]
        [Display(Name = "Price")]
        [Range(typeof(decimal), ValueMinLength, ValueMaxLength)]
        public decimal Value { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Receipt/Invoice")]
        public IFormFile File { get; set; } = null!;
        [Required]
        public Guid UserId { get; set; }

    }
}
