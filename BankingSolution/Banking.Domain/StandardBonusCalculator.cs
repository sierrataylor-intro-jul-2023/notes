namespace Banking.Domain
{
    public class StandardBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
    {
        private readonly IProvideTheBusinessClock _businessClock;
        public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }

        public decimal CalculateBonusForDeposit(decimal balanceOnAccount, decimal amountToDeposit)
        {
            decimal bonusMultiplier = _businessClock.IsDuringBusinessHours() ? .10M : .05M;
            return balanceOnAccount >= 6000M  ?amountToDeposit * bonusMultiplier : 0;
        }
    }
}