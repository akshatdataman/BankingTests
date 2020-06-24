using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class NewAccountTests
    {
        [Fact]
        public void NewAcctsHaveCorrectBalance()
        {
            // "WTCYWYH" "Write the code you wish you had"
            // Given I have a brand new bank account
            var account = new BankAccount();

            // When I retrieve the balance

            decimal balance = account.GetBalance();

            // It has a balance of $5,000.00
            Assert.Equal(5000M, balance);
        }
    }
}

// "Test for Type" BankAccount => BankAccountTests, Customer => CustomerTests
