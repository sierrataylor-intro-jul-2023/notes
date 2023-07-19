
namespace FirstApp.Models
{
    public record StatusResponseModel(DateTime LastChecked, string Message, string Status);
    public record TodoItemModel(Guid Id, string Description, string Status);
}
