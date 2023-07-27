using System.Security.Cryptography.X509Certificates;

namespace EmployeeDirectoryApi
{
    public class StandardBusinessClock : IProvideTheBusinessClock
    {
        private readonly ISystemTime _systemTime;

        public StandardBusinessClock(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        public bool AreWeOpen()
        {

            var now = _systemTime.GetCurrent().Hour;
            return (now >= 9 && now < 17);
        }
    }

    public interface ISystemTime
    {
        DateTime GetCurrent();
    }
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}