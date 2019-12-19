using System.Threading.Tasks;

namespace Chama.Signup.Api.QueueClient
{
    public interface IQueueClient
    {
        Task SendMessage(object message);
    }
}
