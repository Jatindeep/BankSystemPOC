using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Services;
using Web.Models;

namespace Web.Pages.Customer
{
    [Authorize]
    public class TransactionHistoryModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BankingService _bankingService;

        public TransactionHistoryModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            BankingService bankingService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bankingService = bankingService;
        }

        [BindProperty]
        public List<PaymentTransactionViewModel> Transactions { get; set; }
        public void OnGet()
        {
            if (this.User != null)
            {
                var userId = _userManager.GetUserId(User);
                if (userId != null)
                {
                    var allUserTransactions = _bankingService.GetAllUserTransactions(new Guid(userId));
                    if(allUserTransactions != null && allUserTransactions.Any())
                    {
                        Transactions = allUserTransactions.Select(x => new PaymentTransactionViewModel()
                        {
                            TransactionId = x.Id.ToString(),
                            AccountId = x.AccountId.ToString(),
                            Amount = x.Amount.ToString("0.00"),
                            SenderName = x.SenderName,
                            ReceiverName = x.ReceiverName,
                            ReceiverAccountNo = x.ReceiverAccountNo,
                            IsCompleted = x.IsCompleted ? "Completed" : "Failed",
                            CreatedOn = x.CreatedOn.ToString("MMM dd yyyy HH:mm:ss")
                        }).ToList();
                    }
                }
            }
        }
    }
}
