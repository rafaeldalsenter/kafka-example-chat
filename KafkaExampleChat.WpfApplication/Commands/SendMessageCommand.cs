using KafkaExampleChat.Configurations;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Producers;
using KafkaExampleChat.Topics;
using KafkaExampleChat.WpfApplication.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KafkaExampleChat.WpfApplication.Commands
{
    public class SendMessageCommand : ICommand
    {
        private readonly IProducer<ChatMessage> _producer;

        public SendMessageCommand()
        {
            var kafkaConfiguration = new KafkaConfiguration();

            _producer = new Producer(kafkaConfiguration);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var viewModel = parameter as ChatViewModel;
            viewModel.ChatModel.StatusBar = "Enviando...";

            var sendMessageToKafka = SendMessageToKafka(viewModel);

            if (!sendMessageToKafka)
            {
                viewModel.ChatModel.StatusBar = "Ops! Tente novamente!";
                return;
            }

            viewModel.ChatModel.StatusBar = "Enviado!";
            viewModel.ChatModel.Message = string.Empty;
        }

        private bool SendMessageToKafka(ChatViewModel viewModel)
        {
            var task = Task.Run(async () =>
            {
                try
                {
                    var chatMessage = new ChatMessage
                    {
                        Id = Guid.NewGuid(),
                        ProducerId = viewModel.ChatModel.ProducerId,
                        Text = viewModel.ChatModel.Message
                    };

                    await _producer.SendAsync(new MessageTopic(), chatMessage);

                    return true;
                }
                catch
                {
                    return false;
                }
            });

            task.Wait();

            return task.Result;
        }
    }
}