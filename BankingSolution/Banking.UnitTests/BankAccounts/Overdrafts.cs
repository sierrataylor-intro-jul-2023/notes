using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccounts
{
    public class Overdrafts
    {

        [Fact]
        public void DoesNotDecreaseBalanceAndThrowsException()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var openingBalance = account.GetBalance();
            var amountToWithdraw = openingBalance + .01M;

            Assert.Throws<AccountOverdraftException>(() =>
            {
                account.Withdraw(amountToWithdraw);
            });

            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
