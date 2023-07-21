namespace Banking.Domain
{
    public interface IProvideTheBusinessClock
    {
        public bool IsDuringBusinessHours();
    }
}