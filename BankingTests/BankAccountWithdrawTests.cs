using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountWithdrawTests
    {
        private BankAccount _account;
        private decimal _openingBalance;

        public BankAccountWithdrawTests()
        {
            _account = new BankAccount(new DummyBonusCalculator(), new Mock<INarcOnAccounts>().Object);
            _openingBalance = _account.GetBalance();
        }

        [Fact] 
        public void WithdrawMoneyFromBankAccount()
        {
            // Given
            var amountToWithdraw = 1M;

            // When
            _account.Withdraw(amountToWithdraw);

            // Then
            var expectedBalance = _openingBalance - amountToWithdraw;
            Assert.Equal(expectedBalance, _account.GetBalance());
        }

        [Fact]
        public void YouCanTakeAllYourMoney()
        {
            _account.Withdraw(_openingBalance);

            Assert.Equal(0, _account.GetBalance());
        }

        //[Fact]
        //public void TempReplicateIssueWithTakingMoneyToZero()
        //{
        //    var account = new BankAccount();


        //    Assert.Throws<OverdraftException>(() =>
        //    account.Withdraw(account.GetBalance())
        //    );

        //}
    }
}
