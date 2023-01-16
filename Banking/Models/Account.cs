using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace Banking.Models
{
    public class Account
        { 
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Balance { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal OverDraft { get; set; }
        public AccountType AccountType { get; set; }
        public int TotalTransaction { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
            Random generator = new Random();
        public Account() {
            AccountNumber = generator.Next(0, 1000000).ToString("D6"); // generating a new random account number
            AccountName =  FirstName;

        }

        
    }

    public enum AccountType
    {
        Saving, 
        Checking,
        Admin // user won't be able to select this 
    }
}
