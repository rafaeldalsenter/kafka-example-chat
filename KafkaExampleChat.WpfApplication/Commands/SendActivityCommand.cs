using KafkaExampleChat.Messages;
using KafkaExampleChat.Producers;
using KafkaExampleChat.Topics;
using KafkaExampleChat.WpfApplication.ViewModels;
using System;
using System.Windows.Input;

namespace KafkaExampleChat.WpfApplication.Commands
{
    public class SendActivityCommand : BaseCommand<ActivityMessage>, ICommand
    {
        public SendActivityCommand(IProducer<ActivityMessage> producer) : base(producer)
        {
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var viewModel = parameter as ChatViewModel;

            var activityMessage = new ActivityMessage
            {
                Id = Guid.NewGuid(),
                ProducerId = viewModel.ChatModel.ProducerId,
                IsWriting = true
            };

            SendMessageToKafka(viewModel, new ChatActivityTopic(), activityMessage);
        }
    }
}