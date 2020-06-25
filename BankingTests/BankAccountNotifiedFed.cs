using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class BankAccountNotifiedFed
    {
        [Fact]
        public void NotifiedOnWithdrawals()
        {
            // Given - I have a bank account
            var mockedFed = new Mock<INarcOnAccounts>(); // X, if you see Y, write down whatever he says.
            var account = new BankAccount(new Mock<ICalculateBonuses>().Object, mockedFed.Object);


            // When - I withdraw
            account.Withdraw(108);


            // Then the fed is notified.
            mockedFed.Verify(m => m.NotifyOfWithdrawal(account, 108));
        }
    }
}
