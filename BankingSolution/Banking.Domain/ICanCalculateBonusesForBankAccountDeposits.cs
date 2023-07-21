namespace Banking.Domain
{
    public interface ICanCalculateBonusesForBankAccountDeposits
    {
        public decimal CalculateBonusForDeposit(decimal balanceOnAccount, decimal amountToDeposit);
    }
}