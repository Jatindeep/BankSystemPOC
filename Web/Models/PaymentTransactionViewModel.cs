namespace Web.Models
{
    public class PaymentTransactionViewModel
    {
        public string TransactionId { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;
        public string SenderName { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string ReceiverAccountNo { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string CreatedOn { get; set; } = string.Empty;
        public string IsCompleted { get; set; } = string.Empty;
    }
}
