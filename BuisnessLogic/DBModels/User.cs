using System.ComponentModel.DataAnnotations;

namespace BuisnessLogic
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

