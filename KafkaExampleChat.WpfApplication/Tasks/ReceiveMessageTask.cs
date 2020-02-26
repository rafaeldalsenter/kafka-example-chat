using KafkaExampleChat.Configurations;
using KafkaExampleChat.Consumers;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using KafkaExampleChat.WpfApplication.Models;
using KafkaExampleChat.WpfApplication.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaExampleChat.WpfApplication.Tasks
{
    public class ReceiveMessageTask
    {
        private readonly IConsumer<ChatMessage> _consumer;

        public ChatViewModel ViewModel { get; set; }

        public ReceiveMessageTask()
        {
            var kafkaConfiguration = new KafkaConfiguration();

            _consumer = new Consumer(kafkaConfiguration);
        }

        public void Execute(CancellationToken cancellationToken)
        {
            Task.Run(() =>
            {
                _consumer.Execute(new MessageTopic(), Escrever, cancellationToken);
            });
        }

        public void Escrever(ChatMessage chatMessage)
        {
            var messageModel = new MessageModel
            {
                ProducerId = chatMessage.ProducerId,
                Message = chatMessage.Text
            };

            ViewModel.ChatModel.AddMessage(messageModel);
        }
    }
}