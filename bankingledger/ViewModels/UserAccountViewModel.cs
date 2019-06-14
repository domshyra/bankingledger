using System.ComponentModel.DataAnnotations;

namespace BankingLedger.ViewModels
{
    public class UserAccountViewModel
    {
        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }

        public string Id { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }


        [EmailAddress]
        [Required]
        public string Email { get; set; }


        public UserAccountViewModel()
        {

        }
    }
}
