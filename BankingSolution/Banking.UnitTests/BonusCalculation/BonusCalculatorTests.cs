using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BonusCalculation
{
    public class BonusCalculatorTests
    {
        [Theory]
        [InlineData(100, 10)]
        [InlineData(500, 50)]
        public void HasSufficientBalance(decimal amountToDeposit, decimal expectedBonus)
        {
            var duringBusinessHourClock = new Mock<IProvideTheBusinessClock>();
            var bonusCalculator = new StandardBonusCalculator(duringBusinessHourClock.Object);
            var balanceOnAccount = 6000M;

            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountToDeposit);

            Assert.Equal(expectedBonus, bonus);

        }

        [Theory]
        [InlineData(100, 0)]
        [InlineData(500, 0)]
        public void HasInsufficientBalance(decimal amountToDeposit, decimal expectedBonus)
        {
            var duringBusinessHourClock = new Mock<IProvideTheBusinessClock>();
            var bonusCalculator = new StandardBonusCalculator(duringBusinessHourClock.Object);
            var balanceOnAccount = 4999.99M;

            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountToDeposit);

            Assert.Equal(expectedBonus, bonus);

        }

        [Fact]
        public void BonusIsHalfOutsideBusinessHours()
        {
            var duringBusinessHourClock = new Mock<IProvideTheBusinessClock>();
            duringBusinessHourClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);
            var bonusCalculator = new StandardBonusCalculator(duringBusinessHourClock.Object);
            decimal bonus = bonusCalculator.CalculateBonusForDeposit(6000, 100);
            Assert.Equal(105, bonus);
        }


    }
}
