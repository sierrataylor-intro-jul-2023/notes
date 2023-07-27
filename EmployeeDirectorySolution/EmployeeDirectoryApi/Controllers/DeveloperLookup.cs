using EmployeeDirectoryApi.Models;

namespace EmployeeDirectoryApi.Controllers
{
    public class DeveloperLookup : ILookupOnCallDevelopers
    {
        IProvideTheBusinessClock _businessClock;

        public DeveloperLookup(IProvideTheBusinessClock businessClock)
        {
            _businessClock = businessClock;
        }

        public async Task<OnCallDeveloperResponseModel>  OnCallDeveloperLookup()
        {
            bool isDuringBusinessHours = _businessClock.AreWeOpen();
            OnCallDeveloperResponseModel response;
            if (isDuringBusinessHours)
            {
                response = new OnCallDeveloperResponseModel
                {
                    Name = "Sierra",
                    PhoneNumber = "123-4567",
                    Email = "st@aol.com"
                };
            }
            else
            {
                response = new OnCallDeveloperResponseModel
                {
                    Name = "Becky",
                    PhoneNumber = "876-5432",
                    Email = "becky@aol.com"
                };
            }
            return response;
        }
    }
}
