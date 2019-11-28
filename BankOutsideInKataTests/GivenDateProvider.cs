using System;
using BankOutsideInKata;
using NUnit.Framework;
using Shouldly;

namespace BankOutsideInKata_Tests
{
    public class GivenDateProvider
    {
        [Test]
        public void ReturnsTodaysDateCorrectly()
        {
            var dateProvider = new DateProvider();
            var today = DateTime.Today;

            today.ShouldBe(dateProvider.Today());
        }
    }
}
