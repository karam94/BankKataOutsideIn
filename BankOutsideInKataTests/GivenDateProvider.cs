using System;
using BankOutsideInKata;
using NUnit.Framework;
using Shouldly;

namespace BankOutsideInKataTests
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
