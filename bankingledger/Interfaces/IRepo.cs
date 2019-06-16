using System;
using System.Collections.Generic;
using BankingLedger.Entities;

namespace BankingLedger.Interfaces
{
    public interface IRepo
    {
        IEnumerable<Account> GetAccountsForUser(Guid userId);
        decimal MakeDeposit(decimal amount, int accountId);
        decimal MakeWithdrawal(decimal amount, int accountId);
    }
}
