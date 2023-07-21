using FirstApp.Models;

namespace FirstApp.Services
{
    public class RemoteStatusSservice : IProvideTheSystemStatus
    {
        
        public StatusResponseModel GetCurrentStatus()
        {
            return new StatusResponseModel(new DateTime(1969, 4, 20, 23, 59, 00), "The other server says awesome!", "Good Jorb");
        }
    }
}
