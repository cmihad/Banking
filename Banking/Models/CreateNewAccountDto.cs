using System.ComponentModel.DataAnnotations;

namespace Banking.Models
{
    public class CreateNewAccountDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public AccountType AccountType { get; set;}
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
