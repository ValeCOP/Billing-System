namespace ISP_Clients_Web_API.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string ActivationDate { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string ExpiredDate { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Phone { get; set; } = null!;
    }
}
