using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingLedger.Entities;
using BankingLedger.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingLedger.Controllers
{
    public class LedgerAccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILedgerAccountProvider _ledgerAccountProvider;

        public LedgerAccountController(UserManager<ApplicationUser> userManager, ILedgerAccountProvider ledgerAccountProvider)
        {
            _userManager = userManager;
            _ledgerAccountProvider = ledgerAccountProvider;
        }

        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);


            return View(_ledgerAccountProvider.GetLedgerAccountViewModelsForUser(user.Id));
        }
    }
}