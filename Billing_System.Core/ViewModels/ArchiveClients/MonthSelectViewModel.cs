namespace Billing_System.Core.ViewModels.ArchiveClients
{
    using System.ComponentModel.DataAnnotations;

    public class MonthSelectViewModel
    {
        [Required]
        [Display(Name = "Select month")]
        public int SelectedMonth { get; set; }

        public ICollection<ArchiveMonthDetails> archiveMonthsDetails { get; set; } = new List<ArchiveMonthDetails>();



    }
}
