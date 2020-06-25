using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingTests
{
    public class StandardBonusCalculatorTests
    {
        [Theory] 
        [InlineData(100,9999, 0)]
        [InlineData(100,10000, 10)]
        public void CanCalculateBonusesBeforeCutoff(decimal deposit, decimal balance, decimal expected)
        {
            // so, our standard bonus calculator = accounts with a balance > 10000 get 10% bonus.
            var systemTimeFake = new Mock<ISystemTime>();
            systemTimeFake.Setup(s => s.GetCurrent()).Returns(new DateTime(1969, 4, 20, 16, 59, 59));
            ICalculateBonuses bonusCalculator = new StandardBonusCalculator(systemTimeFake.Object);
            var bonus = bonusCalculator.GetDepositBonusFor(deposit, balance);

            Assert.Equal(expected, bonus);
        }

        [Theory]
        [InlineData(100, 9999, 0)]
        [InlineData(100, 10000, 5)]
        public void CanCalculateBonusesAfterCutoff(decimal deposit, decimal balance, decimal expected)
        {
            // so, our standard bonus calculator = accounts with a balance > 10000 get 5% bonus.
            var systemTimeFake = new Mock<ISystemTime>();
            systemTimeFake.Setup(s => s.GetCurrent()).Returns(new DateTime(1969, 4, 20, 17, 00, 00));
            ICalculateBonuses bonusCalculator = new StandardBonusCalculator(systemTimeFake.Object);
            var bonus = bonusCalculator.GetDepositBonusFor(deposit, balance);

            Assert.Equal(expected, bonus);
        }
    }

    //public class TestingStandingBonusCalculator : StandardBonusCalculator
    //{
    //    private bool isBeforeCutoff;

    //    public TestingStandingBonusCalculator(bool isBeforeCutoff)
    //    {
    //        this.isBeforeCutoff = isBeforeCutoff;
    //    }

    //    protected override bool BeforeCutoff()
    //    {
    //        return isBeforeCutoff; // Extend and Override.
    //    }
    //}
}
