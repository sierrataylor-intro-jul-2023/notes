using Banking.Domain;
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
            var account = new BankAccount();
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
            var annAccount = new BankAccount();
            var bobAccount = new BankAccount();

            annAccount.Deposit(100);

            Assert.Equal(5100, annAccount.GetBalance());
            Assert.Equal(5000, bobAccount.GetBalance());
        }
    }
}
