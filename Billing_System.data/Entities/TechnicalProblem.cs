namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Utilities.ValidationConstants.ValidationConstants.TechnicalProblems;
    public class TechnicalProblem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public bool Solved { get; set; }

        [StringLength(1000)]
        [DataType(DataType.Text)]
        public string? Solution { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? ResolvedOn { get; set; }

        public string ClientName { get; set; } = null!;
        public string? ClientPhone { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientAddress { get; set; }

        [Required]
        [ForeignKey("RegisterProblemUser")]
        public Guid RegisterProblemUserId { get; set; }
        public virtual ApplicationUser RegisterProblemUser { get; set; } = null!;

       
        [ForeignKey("ResolvedProblemUser")]
        public Guid? ResolvedProblemUserId { get; set; }
        public virtual ApplicationUser? ResolvedProblemUser { get; set; }


    }
}
