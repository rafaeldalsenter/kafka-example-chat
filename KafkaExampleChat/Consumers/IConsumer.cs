using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using System;
using System.Threading.Tasks;

namespace KafkaExampleChat.Consumers
{
    public interface IConsumer<TMessage> where TMessage : Message
    {
        Task ExecuteAsync(ITopic topic, TMessage message, string producerId, Action<string> actionWriter);
    }
}