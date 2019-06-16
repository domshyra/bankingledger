using System.Collections.Generic;

namespace BankingLedger.ViewModels
{
    public class LedgerAccountViewModel
    {
        public string Name { get; set; }
        public string Balance { get; set; }
        public int AccountId { get; set; }
        public List<DepositViewModel> DepositHistory { get; set; }
    }
}
