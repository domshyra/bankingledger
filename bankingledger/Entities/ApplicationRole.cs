using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BankingLedger.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
            UserRoles = new HashSet<ApplicationUserRole>();
        }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}