using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Services;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BankingService _bankingService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager, BankingService bankingService)
        {
            _logger = logger;
            _userManager = userManager;
            _bankingService = bankingService;
        }

        [BindProperty]
        public decimal Balance { get; set; }

        [BindProperty]
        public string AccountNumber { get; set; } = string.Empty;

        public void OnGet()
        {
            if (User != null)
            {
                var userId = _userManager.GetUserId(User);
                if (userId != null)
                {
                    var account = _bankingService.GetAccountByUserId(new Guid(userId));
                    if(account != null)
                    {
                        Balance = account.Balance;
                        AccountNumber = account.AccountNumber;
                    }
                }
            }
        }
    }
}