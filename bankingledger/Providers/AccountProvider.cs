using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using BankingLedger.Entities;
using BankingLedger.Interfaces;
using BankingLedger.ViewModels;

namespace BankingLedger.Providers
{
    public class AccountProvider : IAccountProvider
    {
        private readonly IRepo _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountProvider(IRepo repo, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _repo = repo;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Create(UserAccountViewModel model)
        {
            //Create a new application user
            ApplicationUser applicationUser = new ApplicationUser
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email
            };
            IdentityResult updateResult = _userManager.CreateAsync(applicationUser).Result;


            IList<string> roles = new List<string>()
            {
                "Customer"
            };

            //Add new roles
            IdentityResult add = _userManager.AddToRolesAsync(applicationUser, roles).Result;

        }

    }
}
