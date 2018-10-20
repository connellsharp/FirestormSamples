using System.Threading.Tasks;

namespace FirestormSample.Domain.Messages
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message);
    }
}