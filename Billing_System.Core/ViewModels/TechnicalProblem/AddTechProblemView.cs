namespace Billing_System.Core.ViewModels.TechnicalProblem
{
    using Billing_System.Data.Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class AddTechProblemView
    {
       

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime RegisteredOn { get; set; } = DateTime.Now;

        [Required]
        public Guid ClientId { get; set; }

        public ICollection<ClientsInfoModel> Clients { get; set; }

        [Required]
        public Guid RegisterProblemUserId { get; set; }
       

    }
}
