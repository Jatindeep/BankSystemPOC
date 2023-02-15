using Domain.Entities.Base;

namespace Domain.Entities
{
    /// <summary>
    /// Transaction data
    /// </summary>
    public class PaymentTransaction : BaseEntity
    {
        public Guid AccountId { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverAccountNo { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public bool IsCompleted { get; set; }

        public Account Account { get; set; } = default!;

    }
}
