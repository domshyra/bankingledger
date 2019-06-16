using System.Collections.Generic;
using System.Linq;
using BankingLedger.ViewModels;
using BankingLedger.Entities;
using BankingLedger.Assemblers;

namespace BankingLedger.Assemblers
{
    public static class LedgerAccountAssembler
    {
        public static LedgerAccountViewModel MakeLedgerAccount(this Account source)
        {
            LedgerAccountViewModel ledgerAccountViewModel = new LedgerAccountViewModel
            {
                AccountId = source.Id,
                Balance = source.Ballance.ToString("C"),
                Name = source.Name

            };

            ledgerAccountViewModel.DepositHistory = source.Deposits.MakeDeposits();

            return ledgerAccountViewModel;
        }

        public static List<LedgerAccountViewModel> MakeLedgerAccounts(this IEnumerable<Account> source)
        {
            return source.Select(r => r.MakeLedgerAccount()).ToList();
        }
    }
}
