using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using System;
using System.Threading.Tasks;

namespace KafkaExampleChat.Consumers
{
    public class Consumer : IConsumer<ChatMessage>
    {
        public async Task ExecuteAsync(ITopic topic, ChatMessage message, string producerId, Action<string> actionWriter)
        {
            if (message.ProducerId.Equals(producerId)) return;

            actionWriter(message.Text);
        }
    }
}