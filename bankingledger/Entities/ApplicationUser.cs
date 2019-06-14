using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BankingLedger.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            UserRoles = new HashSet<ApplicationUserRole>();
            Accounts = new HashSet<Account>();
        }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}