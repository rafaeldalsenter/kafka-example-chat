using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaExampleChat.Consumers
{
    public interface IConsumer<TMessage> where TMessage : Message
    {
        Task ExecuteAsync(string producerId, Action<TMessage> actionWriter, CancellationToken cancellationToken);
    }
}