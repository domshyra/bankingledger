using System.Collections.Generic;
using System.Linq;
using BankingLedger.ViewModels;
using BankingLedger.Entities;

namespace BankingLedger.Assemblers
{
    public static class DepositViewModelAssembler
    {
        public static DepositViewModel MakeDeposit(this Deposit source)
        {
            return new DepositViewModel
            {
                Amount = source.Amount.ToString("C"),
                Balance = source.Ballance.ToString("C"),
                Date = source.Date,
                Id = source.Id
            };
        }

        public static List<DepositViewModel> MakeDeposits(this IEnumerable<Deposit> source)
        {
            return source.Select(r => r.MakeDeposit()).OrderByDescending(x => x.Date).ToList();
        }
    }
}
