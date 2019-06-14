using BankingLedger.Entities;
using BankingLedger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingLedger.Providers
{
    public class Repo : IRepo
    {
        private readonly BankingLedgerDBContext context = new BankingLedgerDBContext();

        public IEnumerable<Account> GetAccountsForUser(Guid userId)
        {
            return context.Accounts.Where(x => Equals(x.UserId, userId));
        }
    }
}
