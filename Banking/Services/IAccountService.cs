using Banking.Models;

namespace Banking.Services
{
    public interface IAccountService
    {
        Account Authenticate(string AccountNumber, string Password);
        public int GetNumberOfAccounts();
        Account CreateAccount(Account account, string Password , string confirmPassword);
        void DeleteAccount(int Id);
        Account getAccountById(int Id);
        Account getAccountbyAccountNumber(string AccountNumber);
       IEnumerable<Account> getAllAccounts();
        public decimal GetAccountBalance(string AccountNumber);
    }
}
