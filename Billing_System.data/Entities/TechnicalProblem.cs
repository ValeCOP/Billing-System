namespace Billing_System.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TechnicalProblem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = null!;

        [Required]
        public bool Solved { get; set; }

        [StringLength(1000)]
        [DataType(DataType.Text)]
        public string? Solution { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

       
        public DateTime ResolvedOn { get; set; }

        [Required]
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        [Required]
        public virtual Client Client { get; set; } = null!;

        [Required]
        [ForeignKey("RegisterProblemUser")]
        public Guid RegisterProblemUserId { get; set; }
        public virtual ApplicationUser RegisterProblemUser { get; set; } = null!;

        [Required]
        [ForeignKey("ResolvedProblemUser")]
        public Guid ResolvedProblemUserId { get; set; }
        public virtual ApplicationUser ResolvedProblemUser { get; set; } = null!;


    }
}
