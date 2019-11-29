using System;
using System.Collections.Generic;
using BankOutsideInKata;
using BankOutsideInKata.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace BankOutsideInKataTests
{
    public class GivenAccountService
    {
        private ITransactionRepository _transactionRepository;
        private IBankStatementPrinter _bankStatementPrinter;
        private AccountService _accountService;

        [SetUp]
        public void Setup()
        {
            _transactionRepository = Substitute.For<ITransactionRepository>();
            _bankStatementPrinter = Substitute.For<IBankStatementPrinter>();
            _accountService = new AccountService(_transactionRepository, _bankStatementPrinter);
        }

        [Test]
        public void WhenDepositAmount_ShouldStoreATransaction()
        {
            _accountService.Deposit(1000);
            _transactionRepository.Received().Save(1000);
        }

        [Test]
        public void WhenWithdrawAmount_ShouldStoreATransaction()
        {
            _accountService.Withdraw(500);
            _transactionRepository.Received().Save(-500);
        }

        [Test]
        public void WhenPrintStatement_ShouldCallBankStatementPrinterInDescendingOrder()
        {
            var fakeOrderedTransactions = new List<Transaction>
            {
                new Transaction(DateTime.Today.AddDays(7), 2000),
                new Transaction(DateTime.Today, 1000)
            };

            _transactionRepository.GetAll().Returns(fakeOrderedTransactions);

            _accountService.PrintStatement();
            _bankStatementPrinter.Received().Print("Date || Amount || Balance");
            _bankStatementPrinter.Received().Print($"{DateTime.Today.AddDays(7):dd'/'MM'/'yyyy} || 2000 || 3000");
            _bankStatementPrinter.Received().Print($"{DateTime.Today:dd'/'MM'/'yyyy} || 1000 || 1000");
        }

        [Test]
        public void WhenPrintStatement_WithComplexTransactions_ShouldCallBankStatementPrinterInDescendingOrder()
        {
            var fakeOrderedTransactions = new List<Transaction>
            {
                new Transaction(DateTime.Today.AddDays(7), -500),
                new Transaction(DateTime.Today.AddDays(4), 2000),
                new Transaction(DateTime.Today, 1000)
            };

            _transactionRepository.GetAll().Returns(fakeOrderedTransactions);

            _accountService.PrintStatement();
            _bankStatementPrinter.Received().Print("Date || Amount || Balance");
            _bankStatementPrinter.Received().Print($"{DateTime.Today.AddDays(7):dd'/'MM'/'yyyy} || -500 || 2500");
            _bankStatementPrinter.Received().Print($"{DateTime.Today.AddDays(4):dd'/'MM'/'yyyy} || 2000 || 3000");
            _bankStatementPrinter.Received().Print($"{DateTime.Today:dd'/'MM'/'yyyy} || 1000 || 1000");
        }
    }
}
