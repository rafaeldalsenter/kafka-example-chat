using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using System;
using System.Threading;

namespace KafkaExampleChat.Consumers
{
    public interface IConsumer<TMessage> where TMessage : Message
    {
        void Execute(ITopic topic, Action<TMessage> actionWriter, CancellationToken cancellationToken);
    }
}