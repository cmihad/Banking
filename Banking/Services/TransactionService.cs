using Banking.Data;
using Banking.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.Services
{
    public class TransactionService : ITransactionService
    {

        private ApplicationDbContext _dbcontext;
        public TransactionService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Account Deposit(string AccountNumber, decimal Amount)
        {
            var result = _dbcontext.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            var transaction = new Transaction();
            transaction.AccountNumber = AccountNumber;
            transaction.Amount = Amount;
            transaction.ReceiverInfo = "null";
            transaction.SenderInfo = "null";
            transaction.TransactionType = (TransactionType)1;

            var currentbalance = result.Balance + Amount;
            _dbcontext.Accounts
              .Where(u => u.AccountNumber == AccountNumber)
                .ExecuteUpdate(b =>
              b.SetProperty(u => u.Balance, currentbalance)
          );




            _dbcontext.Transactions.Add(transaction);
            _dbcontext.SaveChanges();
            return result;
        }

 

        public Account getAccountbyAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }


        public int TotalNumberOfTransactions(string AccountNumber)
        {
            var NumberOfTransactions = _dbcontext.Transactions.Where(x => x.AccountNumber == AccountNumber).Count();
            return NumberOfTransactions;

        }

        public TransactionService Transfer(string AccountNumber, string Password)
        {
            throw new NotImplementedException();
        }

      

        Account ITransactionService.WIthdraw(string AccountNumber, decimal Amount)
        {
            var result = _dbcontext.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            var transaction = new Transaction();
            transaction.AccountNumber = AccountNumber;
            transaction.Amount = Amount;
            transaction.ReceiverInfo = "null";
            transaction.SenderInfo = "null";
            transaction.TransactionType = 0;

            var currentbalance = result.Balance - Amount;
            if (Amount > result.Balance) throw new ApplicationException("don't have enought money");


            _dbcontext.Accounts
              .Where(u => u.AccountNumber == AccountNumber)
                .ExecuteUpdate(b =>
              b.SetProperty(u => u.Balance, currentbalance)
          );




            _dbcontext.Transactions.Add(transaction);
            _dbcontext.SaveChanges();
            return result;
        }

        IEnumerable<Transaction> ITransactionService.GenerateReport(string AccountNumber)
        {
            var result = _dbcontext.Accounts.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
            var transactions = _dbcontext.Transactions.Where(x => x.AccountNumber == result.AccountNumber).ToList();

            return transactions;
        }

   
    }
}
