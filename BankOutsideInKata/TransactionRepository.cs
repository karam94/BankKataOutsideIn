using System.Collections.Generic;
using System.Linq;
using BankOutsideInKata.Interfaces;

namespace BankOutsideInKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDateProvider _dateProvider;
        private List<Transaction> _transactions;

        public TransactionRepository(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _transactions = new List<Transaction>();
        }

        public void Save(int amount)
        {
            var newTransaction = new Transaction(_dateProvider.Today(), amount);
            _transactions.Add(newTransaction);
        }

        public List<Transaction> GetAll()
        {
            return _transactions.OrderByDescending(x => x.TransactionDate).ToList();
        }
    }
}