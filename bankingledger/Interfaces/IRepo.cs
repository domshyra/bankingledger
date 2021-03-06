﻿using System;
using System.Collections.Generic;
using BankingLedger.Entities;

namespace BankingLedger.Interfaces
{
    public interface IRepo
    {
        IEnumerable<Account> GetAccountsForUser(Guid userId);
        decimal MakeDeposit(decimal amount, int accountId);
        decimal MakeWithdrawal(decimal amount, int accountId);
        decimal GetAccountBallance(int accountId);
        IEnumerable<Deposit> GetDeposits(int accountId);
        void CreateNewAccount(Account account);
    }
}
