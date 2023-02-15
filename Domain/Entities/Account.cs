using Domain.Entities.Base;

namespace Domain.Entities
{
    /// <summary>
    /// Account Data
    /// </summary>
    public class Account : BaseEntity
    {
        public Guid UserId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public List<PaymentTransaction> PaymentTransactions { get; set; }

    }
}
