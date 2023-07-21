using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccounts
{
    public class DepositUseTheBonusCalculator
    {
        [Fact]
        public void BonusCalculatorIsUsedAndBonusAppliedToBalance()
        {
            // given
            var stubbedBonusCalculator = new Mock<ICanCalculateBonusesForBankAccountDeposits>();
            var account = new BankAccount(stubbedBonusCalculator.Object);

            var openingBalance = account.GetBalance();
            var amountToDeposit = 112.23M;
            var amountOfBonusToReturn = 69.23M;

            stubbedBonusCalculator.Setup(x => x.CalculateBonusForDeposit(openingBalance, amountToDeposit)).Returns(amountOfBonusToReturn);

            //when
            account.Deposit(amountToDeposit);

            //then
            Assert.Equal(openingBalance + amountOfBonusToReturn + amountToDeposit, account.GetBalance());

        }
    }

    //public class StubbedBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
    //{

    //}
}
