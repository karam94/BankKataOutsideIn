using System.Linq;
using BankOutsideInKata.Interfaces;

namespace BankOutsideInKata
{
    public class AccountService : IAccountService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBankStatementPrinter _bankStatementPrinter;

        public AccountService(ITransactionRepository transactionRepository,
            IBankStatementPrinter bankStatementPrinter)
        {
            _transactionRepository = transactionRepository;
            _bankStatementPrinter = bankStatementPrinter;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.Save(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.Save(-amount);
        }

        public void PrintStatement()
        {
            _bankStatementPrinter.Print("Date || Amount || Balance");

            var transactionsToPrint = _transactionRepository.GetAll();
            var runningBalance = transactionsToPrint.Sum(x => x.Amount);

            foreach (var transaction in transactionsToPrint)
            {
                _bankStatementPrinter.Print(
                    $"{transaction.TransactionDate:dd'/'MM'/'yyyy} || {transaction.Amount} || {runningBalance}");

                runningBalance -= transaction.Amount;
            }
        }
    }
}