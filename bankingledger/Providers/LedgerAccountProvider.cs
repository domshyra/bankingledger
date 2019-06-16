using BankingLedger.Interfaces;
using BankingLedger.ViewModels;
using BankingLedger.Assemblers;
using System;
using System.Collections.Generic;

namespace BankingLedger.Providers
{
    public class LedgerAccountProvider : ILedgerAccountProvider
    {
        private readonly IRepo _repo;

        public LedgerAccountProvider(IRepo repo)
        {
            _repo = repo;
        }

        public List<LedgerAccountViewModel> GetLedgerAccountViewModelsForUser(Guid userId)
        {
            return _repo.GetAccountsForUser(userId).MakeLedgerAccounts();
        }

        public decimal Deposit(decimal amount, int accountId)
        {
            return _repo.MakeDeposit(amount, accountId);
        }
        public decimal Withdrawal(decimal amount, int accountId)
        {
            return _repo.MakeDeposit(amount, accountId);
        }
    }
}
