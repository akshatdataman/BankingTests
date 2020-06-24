using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BankingDomain;

namespace BankingTests
{
    public class GoldAccountDeposits
    {
        [Fact]
        public void GoldAccountGetABonusForDeposits()
        {
            var account = new GoldAccount();
            var openingBalance = account.GetBalance();

            account.Deposit(100M);

            var expectedBalance = 110M + openingBalance;
            Assert.Equal(expectedBalance, account.GetBalance());
        }
    }
}
