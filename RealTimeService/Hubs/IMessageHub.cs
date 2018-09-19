using System.Threading.Tasks;

namespace RealTimeService.Hubs
{
    public interface IMessageHub
    {
        Task MessageFromServer(string jsonMessage);
        Task InfoMessageFromServer(string jsonMessage);
        Task SuccessMessageFromServer(string jsonMessage);
        Task WarningMessageFromServer(string jsonMessage);
        Task ErrorMessageFromServer(string jsonMessage);
    }
}
