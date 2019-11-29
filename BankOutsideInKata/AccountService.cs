using System.Collections.Generic;
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
            var accountTransactions = GetAccountTransactions();
            var runningBalance = CalculateAccountTransactionsBalance(accountTransactions);

            _bankStatementPrinter.Print("Date || Amount || Balance");

            foreach (var transaction in accountTransactions)
            {
                _bankStatementPrinter.Print(
                    $"{transaction.TransactionDate:dd'/'MM'/'yyyy} || {transaction.Amount} || {runningBalance}");

                runningBalance -= transaction.Amount;
            }
        }

        private IEnumerable<Transaction> GetAccountTransactions()
        {
            return _transactionRepository.GetAll();
        }

        private int CalculateAccountTransactionsBalance(IEnumerable<Transaction> transactions)
        {
            return transactions.Sum(x => x.Amount);
        }
    }
}