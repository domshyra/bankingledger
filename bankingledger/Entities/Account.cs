using System;
using System.Collections.Generic;

namespace BankingLedger.Entities
{
    public partial class Account
    {
        public Guid UserId { get; set; }
        public int Id { get;  set; }
        public string Name { get; set; }
        public decimal Ballance { get; set; }


        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}