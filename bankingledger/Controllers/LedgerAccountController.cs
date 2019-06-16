using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingLedger.Entities;
using BankingLedger.Interfaces;
using BankingLedger.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankingLedger.Controllers
{
    [Authorize(Policy = "Customer")]
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

        public async Task<ActionResult> CreateNewAccount()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            CreateNewLedgerAccountViewModel model = new CreateNewLedgerAccountViewModel
            {
                UserId = user.Id
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewAccount(CreateNewLedgerAccountViewModel form)
        {
            _ledgerAccountProvider.CreateNewAccount(form);

            return RedirectToAction("Index");
        }

        public string MakeDeposit(decimal amount, int accountId)
        {
            string result = _ledgerAccountProvider.Deposit(amount, accountId);
            return JsonConvert.SerializeObject(result);
        }
        public string MakeWithdrawal(decimal amount, int accountId)
        {
            return JsonConvert.SerializeObject(_ledgerAccountProvider.Withdrawal(amount, accountId));
        }
        public ActionResult GetDepositHistory(int accountId)
        {
            List<DepositViewModel> deposits = _ledgerAccountProvider.GetDepositHistory(accountId);

            return PartialView("_DepositHistory", deposits);
        }
    }
}