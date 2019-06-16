using System;
using System.Collections.Generic;
using BankingLedger.ViewModels;

namespace BankingLedger.Interfaces
{
    public interface ILedgerAccountProvider
    {
        List<LedgerAccountViewModel> GetLedgerAccountViewModelsForUser(Guid userId);

        string Deposit(decimal amount, int accountId);
        WithdrawMessage Withdrawal(decimal amount, int accountId);
        List<DepositViewModel> GetDepositHistory(int accountId);
        void CreateNewAccount(CreateNewLedgerAccountViewModel form);
    }
}