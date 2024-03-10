namespace Billing_System.Core.ViewModels.ArchiveClients
{
    using System.ComponentModel.DataAnnotations;

    public class MonthSelectViewModel
    {
        [Required]
        [Display(Name = "Archive in:")]
        public int SelectedMonth { get; set; }

        public ICollection<ArchiveMonthDetails> ArchiveMonthsDetails { get; set; } = new List<ArchiveMonthDetails>();
    }
}
