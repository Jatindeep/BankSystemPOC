using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Services;
using Web.Models;

namespace Web.Pages.Customer
{
    [Authorize]
    public class TransferFundsModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BankingService _bankingService;

        public TransferFundsModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            BankingService bankingService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bankingService = bankingService;
        }

        [BindProperty]
        public TransferFundsInputModel Input { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && this.User != null)
            {
                var userId = _userManager.GetUserId(User);
                if (userId != null)
                {
                    var transaction = _bankingService.TransferAmount(new Guid(userId), Input.Amount, Input.ReceiverName, Input.ReceiverAccountNo, Input.SenderName);
                    return RedirectToPage("Index", new { transactionId = transaction });
                }
            }
            return Page();
        }
    }
}
