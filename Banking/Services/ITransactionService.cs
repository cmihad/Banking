using Banking.Models;

namespace Banking.Services
{
    public interface ITransactionService
    {
        Account Deposit(string AccountNumber, Decimal Amount);
        Account WIthdraw(string AccountNumber, Decimal  Amount);
        public int TotalNumberOfTransactions(string AccountNumber);
        TransactionService Transfer(string AccountNumber, string Password);
        IEnumerable<Transaction> GenerateReport(string AccountNumber);

        Account getAccountbyAccountNumber(string AccountNumber);

        
    }
}
