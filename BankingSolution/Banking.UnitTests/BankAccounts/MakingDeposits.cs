using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccounts
{
    public class MakingDeposits
    {
        [Fact]
        public void DepositsIncreaseBalance()
        {

            //given - arrange
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100.23M;
            //when - act
            account.Deposit(amountToDeposit);

            //then - assert
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }

        [Fact(Skip = "Just a dmeo")]
        public void Demo()
        {
            var annAccount = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var bobAccount = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);

            annAccount.Deposit(100);

            Assert.Equal(5100, annAccount.GetBalance());
            Assert.Equal(5000, bobAccount.GetBalance());
        }
    }

    public class DummyBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
    {
        public decimal CalculateBonusForDeposit(decimal balance, decimal amountToDeposit)
        {
            return 0;
        }
    }
}
