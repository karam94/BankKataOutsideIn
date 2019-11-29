using System;
using BankOutsideInKata;
using BankOutsideInKata.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace BankOutsideInKataTests.AcceptanceTests
{
    // Acceptance Test of the whole system.
    // Started with scaffolding out this test to represent our desired behaviour/feature.
    // Then just resolve each NotImplementedException of scaffolding bit by bit.
    // For each NotImplementedException we move inwards to resolve it, we write tests around it.
    // Over time, we keep moving down the acceptance test until we're fully green!
    public class PrintBankStatementFeature
    {
        [Test]
        public void WhenIPrintBankStatement_ItContainsAllTransactions()
        {
            var dateTimeProvider = Substitute.For<IDateProvider>();
            var transactionRepository = new TransactionRepository(dateTimeProvider);
            var bankStatementPrinter = Substitute.For<IBankStatementPrinter>();
            var accountService = new AccountService(transactionRepository, bankStatementPrinter);

            dateTimeProvider.Today().Returns(DateTime.Parse("10/01/2012"));
            accountService.Deposit(1000);

            dateTimeProvider.Today().Returns(DateTime.Parse("13/01/2012"));
            accountService.Deposit(2000);

            dateTimeProvider.Today().Returns(DateTime.Parse("14/01/2012"));
            accountService.Withdraw(500);

            accountService.PrintStatement();
            bankStatementPrinter.Received().Print("Date || Amount || Balance");
            bankStatementPrinter.Received().Print("14/01/2012 || -500 || 2500");
            bankStatementPrinter.Received().Print("13/01/2012 || 2000 || 3000");
            bankStatementPrinter.Received().Print("10/01/2012 || 1000 || 1000");
        }
    }
}