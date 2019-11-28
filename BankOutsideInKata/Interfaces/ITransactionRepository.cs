using System.Collections.Generic;

namespace BankOutsideInKata.Interfaces
{
    public interface ITransactionRepository
    {
        void Save(int amount);
        List<Transaction> GetAll();
    }
}