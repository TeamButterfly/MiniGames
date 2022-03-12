using System.ComponentModel.DataAnnotations;

namespace BuisnessLogic
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }

        public int Points { get; set; }

        public Guid UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
