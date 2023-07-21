using FirstApp.Models;

namespace FirstApp.Services
{
    public interface IProvideTheSystemStatus
    {
        StatusResponseModel GetCurrentStatus();
    }
}
