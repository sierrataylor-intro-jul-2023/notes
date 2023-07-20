﻿namespace Banking.Domain
{
    public class BankAccount
    {
        decimal _balance = 5000;
        public void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }

        public decimal GetBalance()
        {
            //
            return _balance;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            GuardCorrectTransactionAmount(amountToWithdraw);
            GuardSufficientBalance(amountToWithdraw);
            _balance -= amountToWithdraw;
        }

        private void GuardSufficientBalance(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new AccountOverdraftException();
            }
        }
        private void GuardCorrectTransactionAmount(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= 0)
            {
                throw new InvalidBankAccountTransactionAmountException();
            }
        }
    }
}