using AntDesign;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Infrastructure.Services
{
    public interface IMessageNotificator
    {
        Task ShowError(string message);

        Task ShowSuccess(string message);

        Task ShowWarning(string message);

        Task ShowInfo(string message);
    }
}
