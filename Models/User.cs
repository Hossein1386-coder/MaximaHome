using System.ComponentModel.DataAnnotations;

namespace MaximaHome.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }

        [Required]
        [Phone]
        public required string PhoneNumber { get; set; }

        [Required]
        public required string Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
} 