using FirstApp.Models;

namespace FirstApp.Services
{
    public class StatusService : IProvideTheSystemStatus
    {
        private readonly ISystemTime _systemTime;

        public StatusService(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        public StatusResponseModel GetCurrentStatus()
        {
            // put real code here. ;)
            return new StatusResponseModel(_systemTime.GetCurrent(), "Status Service Looks Good", "Awesome");

        }
    }
}
}
