namespace BuisnessLogic
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public int Points { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
