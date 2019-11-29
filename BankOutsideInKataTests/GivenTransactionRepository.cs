using System;
using System.Linq;
using BankOutsideInKata;
using BankOutsideInKata.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace BankOutsideInKataTests
{
    public class GivenTransactionRepository
    {
        private IDateProvider _dateProvider;
        private TransactionRepository _transactionRepository;

        [SetUp]
        public void Setup()
        {
            _dateProvider = Substitute.For<IDateProvider>();
            _dateProvider.Today().Returns(DateTime.Today);

            _transactionRepository = new TransactionRepository(_dateProvider);
            _transactionRepository.Save(1000);
            _dateProvider.Today().Returns(DateTime.Today.AddDays(7));
            _transactionRepository.Save(2000);
        }

        [Test]
        public void WhenTransactionSaved_ItIsPersisted()
        {
            var savedTransactions = _transactionRepository.GetAll();
            savedTransactions.ShouldContain(t => t.TransactionDate == DateTime.Today && t.Amount == 1000);
        }

        [Test]
        public void WhenGettingAllTransactions_TheyAreReturnedInDescendingOrder()
        {
            var returnedTransactions = _transactionRepository.GetAll();
            returnedTransactions.First().TransactionDate.ShouldBe(DateTime.Today.AddDays(7));
        }
    }
}
