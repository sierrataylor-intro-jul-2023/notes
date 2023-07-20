using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccounts
{
    public class GoldAccountScratch
    {
        [Fact]
        public void GoldAccountGetBonusOnDeposit()
        {
            //given
            var account = new GoldBankAccount();
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100M;
            
            //when
            account.Deposit(amountToDeposit);

            //then
            Assert.Equal(amountToDeposit + 10M + openingBalance, account.GetBalance());

        }
    }
}
