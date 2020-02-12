using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using System;
using System.Threading.Tasks;

namespace KafkaExampleChat.Producers
{
    public class Producer : IProducer<ChatMessage>
    {
        public async Task SendAsync(ITopic topic, ChatMessage message)
        {
            // TODO Montar o envio da mensagem ao topico kafka

            throw new NotImplementedException();
        }
    }
}