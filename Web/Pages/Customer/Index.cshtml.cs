using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Services;
using Web.Models;

namespace Web.Pages.Customer
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly BankingService _bankingService;

        public IndexModel(BankingService bankingService)
        {
            _bankingService = bankingService;
        }
        [BindProperty]
        public PaymentTransactionViewModel Transaction { get; set; }

        public void OnGet(string transactionId)
        {
            var transaction = _bankingService.GetTransactionById(new Guid(transactionId));
            if (transaction != null)
            {
                Transaction = new PaymentTransactionViewModel()
                {
                    TransactionId = transaction.Id.ToString(),
                    AccountId = transaction.AccountId.ToString(),
                    Amount = transaction.Amount.ToString("0.00"),
                    SenderName = transaction.SenderName,
                    ReceiverName = transaction.ReceiverName,
                    ReceiverAccountNo = transaction.ReceiverAccountNo,
                    IsCompleted = transaction.IsCompleted ? "Completed" : "Failed",
                    CreatedOn = transaction.CreatedOn.ToString("MMM dd yyyy HH:mm:ss")
                };
            }
        }
    }
}
