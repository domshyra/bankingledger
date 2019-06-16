using BankingLedger.Entities;
using BankingLedger.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return context.Accounts.Include(x => x.Deposits).Where(x => Equals(x.UserId, userId));
        }

        public decimal GetAccountBallance(int accountId)
        {
            Account account = context.Accounts.Include(x => x.Deposits).FirstOrDefault(x => x.Id == accountId);

            if (account == null)
            {
                throw new ArgumentNullException();
            }

            return account.Ballance;
        }

        public decimal MakeWithdrawal(decimal amount, int accountId)
        {
            Account account = context.Accounts.Include(x => x.Deposits).FirstOrDefault(x => x.Id == accountId);

            if (account == null)
            {
                throw new ArgumentNullException();
            }

            //amount comes in negative
            account.Ballance = account.Ballance + amount;

            Deposit deposit = new Deposit
            {
                Date = DateTime.Now,
                AccountId = accountId,
                Amount = amount,
                Ballance = account.Ballance
            };

            account.Deposits.Add(deposit);

            context.SaveChanges();

            return account.Ballance;
        }

        public decimal MakeDeposit(decimal amount, int accountId)
        {
            Account account = context.Accounts.Include(x => x.Deposits).FirstOrDefault(x => x.Id == accountId);

            if (account == null)
            {
                throw new ArgumentNullException();
            }

            account.Ballance = account.Ballance + amount;

            Deposit deposit = new Deposit
            {
                Date = DateTime.Now,
                AccountId = accountId,
                Amount = amount,
                Ballance = account.Ballance
            };

            account.Deposits.Add(deposit);

            context.SaveChanges();

            return account.Ballance;
        }
        public IEnumerable<Deposit> GetDeposits(int accountId)
        {
            return context.Deposits.Where(x => x.AccountId == accountId);
        }

        public void CreateNewAccount(Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }
    }
}
