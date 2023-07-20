using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccounts
{
    public class MakingWithdrawals
    {
        [Fact]
        public void MakingWithdrawalDecreasesTheBalance()
        {

            //given
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1.01M;

            //when
            account.Withdraw(amountToWithdraw);

            //then
            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }

        [Fact]
        public void CanTakeEntireBalance()
        {
            var account = new BankAccount();
            account.Withdraw(account.GetBalance());
            Assert.Equal(0, account.GetBalance());
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(0)]
        public void InvalidAmountsNotAllowed(decimal amount)
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            Assert.Throws<InvalidBankAccountTransactionAmountException>(() =>
            {
                account.Withdraw(amount);
            });
            Assert.Equal(openingBalance, account.GetBalance());
        }

        //[Theory]
        //[InlineData(80)]
        //[InlineData(9000)]
        //public void ExploreWithdrawals(decimal amountToWithdraw)
        //{
        //    var account = new BankAccount();
        //    var originalBalance = account.GetBalance();

        //    account.Withdraw(amountToWithdraw);

        //    Assert.Equal(originalBalance -  amountToWithdraw, account.GetBalance());
        //}
    }
}
