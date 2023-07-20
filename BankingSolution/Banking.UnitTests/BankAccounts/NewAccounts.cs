using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccounts
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectOpeningBalance()
        {
            var account = new BankAccount();
            decimal balance = account.GetBalance();
            Assert.Equal(5000, balance);
        }
    }
}
