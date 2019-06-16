using System;
using System.Collections.Generic;
using BankingLedger.ViewModels;

namespace BankingLedger.Interfaces
{
    public interface ILedgerAccountProvider
    {
        List<LedgerAccountViewModel> GetLedgerAccountViewModelsForUser(Guid userId);

        decimal Deposit(decimal amount, int accountId);
        decimal Withdrawal(decimal amount, int accountId);
    }
}