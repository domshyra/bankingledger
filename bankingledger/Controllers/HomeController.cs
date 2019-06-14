using BankingLedger.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingLedger.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUser _currentUser = new ApplicationUser();
        private UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "LedgerAccount");
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = string.Empty });
            }

        }

        public ActionResult Registered()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}