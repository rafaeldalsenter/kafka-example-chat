using Confluent.Kafka;
using KafkaExampleChat.Configurations;
using KafkaExampleChat.Consumers;
using KafkaExampleChat.Messages;
using KafkaExampleChat.WpfApplication.Models;
using KafkaExampleChat.WpfApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace KafkaExampleChat.WpfApplication.Tasks
{
    public class ReceiveMessageTask
    {
        private readonly IConsumer<ChatMessage> _consumer;

        public ChatViewModel ViewModel { get; set; }

        public ReceiveMessageTask()
        {
            var kafkaConfiguration = new KafkaConfiguration("localhost:9092", ClasseEstaticaTeste.GetClientId, BrokerAddressFamily.Any);

            _consumer = new Consumer(kafkaConfiguration);
        }

        public void Execute(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                await _consumer.ExecuteAsync(ViewModel.ChatModel.ProducerId, Escrever, cancellationToken);
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