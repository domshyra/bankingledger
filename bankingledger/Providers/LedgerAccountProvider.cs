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

        public string Deposit(decimal amount, int accountId)
        {
            return _repo.MakeDeposit(amount, accountId).ToString("C");
        }
        public WithdrawMessage Withdrawal(decimal amount, int accountId)
        {
            decimal ballance = _repo.GetAccountBallance(accountId);

            if (ballance <= amount)
            {
                return new WithdrawMessage
                {
                    Success = false,
                    Ballance = ballance.ToString("C")
                };
            }

            else
            {
                return new WithdrawMessage
                {
                    Success = true,
                    Ballance = _repo.MakeDeposit(amount, accountId).ToString("C")
                };
            }
        }
        public List<DepositViewModel> GetDepositHistory(int accountId)
        {
            return _repo.GetDeposits(accountId).MakeDeposits();
        }
    }
}
