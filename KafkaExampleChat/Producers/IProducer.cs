using KafkaExampleChat.Contracts;
using KafkaExampleChat.Topics;
using System.Threading.Tasks;

namespace KafkaExampleChat.Producers
{
    public interface IProducer
    {
        Task SendAsync(ITopic topic, Message message);
    }
}