using System;

namespace BankingLedger.ViewModels
{
    public class DepositViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}