using System;

namespace BankOutsideInKata
{
    public class Transaction
    {
        public DateTime TransactionDate { get; }
        public int Amount { get; }

        public Transaction(DateTime transactionDate, int amount)
        {
            TransactionDate = transactionDate;
            Amount = amount;
        }
    }
}