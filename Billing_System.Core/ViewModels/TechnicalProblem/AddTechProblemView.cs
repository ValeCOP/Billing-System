namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    using System.ComponentModel.DataAnnotations;

    public class AddTechProblemView
    {
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime RegisteredOn { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Send Mail")]
        public bool SendMail { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public string ClientName { get; set; } = null!;

        public ICollection<ClientsInfoModel> Clients { get; set; } = new List<ClientsInfoModel>();

        [Required]
        public Guid RegisterProblemUserId { get; set; }
       

    }
}
