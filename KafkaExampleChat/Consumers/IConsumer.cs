using KafkaExampleChat.Contracts;
using KafkaExampleChat.Topics;
using System.Threading.Tasks;

namespace KafkaExampleChat.Consumers
{
    public interface IConsumer
    {
        Task ExecuteAsync(ITopic topic, Message message);
    }
}