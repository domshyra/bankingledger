using BankingLedger.ViewModels;

namespace BankingLedger.Interfaces
{
    public interface IAccountProvider
    {
        void Create(UserAccountViewModel model);
    }
}