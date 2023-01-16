using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Banking.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string TransactionId { get; set; }

        public decimal? Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string AccountNumber { get; set; }
        public string SenderInfo { get; set; }
        public string ReceiverInfo { get; set; }
        Random generator = new();
        public DateTime created { get; set; }
        public Transaction()
        {
            TransactionId = generator.Next(0, 1000000).ToString("D9"); // generating random transaction id
            created= DateTime.UtcNow; // assigning current time when when it's created
        }
    }
       
    public enum TransactionType
    {
        withdraw,
        deposit,
        transfer
    }
}
