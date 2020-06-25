using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BadAmountTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-0.1)]
        [InlineData(-1)]
        public void DepositingNegativeMoneyThrowsException(decimal amount)
        {
            var account = new BankAccount(null, null);

            Assert.Throws<BadAmountException>(() => account.Deposit(amount));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-0.1)]
        [InlineData(-1)]
        public void WithdrawingNegativeMoneyThrowsException(decimal amount)
        {
            var account = new BankAccount(null, null);

            Assert.Throws<BadAmountException>(() => account.Withdraw(amount));
        }
    }
}
