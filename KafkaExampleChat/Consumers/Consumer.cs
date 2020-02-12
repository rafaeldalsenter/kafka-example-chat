using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using System;
using System.Threading.Tasks;

namespace KafkaExampleChat.Consumers
{
    public class Consumer : IConsumer<ChatMessage>
    {
        public async Task ExecuteAsync(ITopic topic, ChatMessage message, Action<string> actionWriter)
        {
            // Ao consumir, vai acionar a action passando a mensagem para ser escrita na tela

            throw new NotImplementedException();
        }
    }
}