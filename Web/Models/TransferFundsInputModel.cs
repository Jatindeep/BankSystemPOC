using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class TransferFundsInputModel
    {
        [Required]
        [Display(Name = "Amount to Transfer")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Enter Receiver Name")]
        public string ReceiverName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Enter Bank Account Number of Receiver")]
        public string ReceiverAccountNo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Enter Sender Name")]
        public string SenderName { get; set; } = string.Empty;

    }
}
