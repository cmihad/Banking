using Banking.Data;
using Banking.Models;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Security.Cryptography;

namespace Banking.Services
{
    public class AccountService : IAccountService
    {

        private ApplicationDbContext _dbcontext;
        public AccountService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Account Authenticate(string AccountNumber, string Password)
        {

            var account = _dbcontext.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();

            if (account == null) throw new ApplicationException("no account with this account number exist");

            var checkHash = passwordHashed(Password);
            if (checkHash.Equals(account.Password))
            {
                return account;
            }
            else throw new ApplicationException(" Password Incorrect");
        }

    


        public Account CreateAccount(Account account, string Password, string confirmPassword)
        {
            var accountExist = _dbcontext.Accounts.Where(x => x.Email == account.Email).FirstOrDefault();
            if (accountExist != null) throw new ApplicationException("Email Already in use");

            var passwordHashed1 = "";
            passwordHashed1 = passwordHashed(Password);
            account.Password=passwordHashed1;
            _dbcontext.Accounts.Add(account);
            _dbcontext.SaveChanges();
            return account;
        }
        public static string passwordHashed(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {



                var ashByteArray = Encoding.Default.GetBytes(password);
                var hash = sha256.ComputeHash(ashByteArray);

                var hashedPassword = Convert.ToBase64String(hash);

                return hashedPassword;
            }

        }

        public void DeleteAccount(int Id)
        {
            var account = _dbcontext.Accounts.Find(Id);

            if (account != null)
            {
                _dbcontext.Accounts.Remove(account);
                _dbcontext.SaveChanges();
            }

        }

        public Account getAccountById(int Id)
        {

            var accountBalance = _dbcontext.Accounts.Find(Id);
                if(accountBalance== null)
            {

            return null;
            }
            else
            {
                return accountBalance;
            }


        }

        public Account getAccountbyAccountNumber(string AccountNumber)
        {
            var accountBalance = _dbcontext.Accounts.Where(x=>x.AccountNumber==AccountNumber).FirstOrDefault();
            if (accountBalance == null)
            {

                return null;
            }
            else
            {
                return accountBalance;
            }

        }

        public int GetNumberOfAccounts()
        {
            var numberOfAccounts = _dbcontext.Accounts.Count();
            return numberOfAccounts;

        }

        public IEnumerable<Account> getAllAccounts()
        {

            var allAccounts = _dbcontext.Accounts.ToList();
            if(allAccounts != null)
            {
                return allAccounts;
            }
            return null;
        }

        public decimal GetAccountBalance(string AccountNumber)
        {
            var result = _dbcontext.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            var amount = result.Balance;
            return amount;
        }
    }
}
