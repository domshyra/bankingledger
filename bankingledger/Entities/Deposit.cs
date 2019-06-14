using System;

namespace BankingLedger.Entities
{
    public class Deposit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }


        public Account Account { get; set; }
    }
}