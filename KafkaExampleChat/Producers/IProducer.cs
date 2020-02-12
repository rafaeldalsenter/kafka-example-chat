using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using System.Threading.Tasks;

namespace KafkaExampleChat.Producers
{
    public interface IProducer<TMessage> where TMessage : Message
    {
        Task SendAsync(ITopic topic, TMessage message);
    }
}