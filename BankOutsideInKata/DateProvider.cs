using System;
using BankOutsideInKata.Interfaces;

namespace BankOutsideInKata
{
    public class DateProvider : IDateProvider
    {
        public DateTime Today()
        {
            return DateTime.Today;
        }
    }
}