using KafkaExampleChat.WpfApplication.Commands;
using KafkaExampleChat.WpfApplication.Models;

namespace KafkaExampleChat.WpfApplication.ViewModels
{
    public class ChatViewModel
    {
        private Chat _chat;
        private SendMessageCommand _sendMessageCommand;

        public ChatViewModel()
        {
            _chat = new Chat();
        }

        public Chat Chat
        {
            get { return _chat; }
            set
            {
                _chat = value;
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }

        public SendMessageCommand SendMessageCommand
        {
            get
            {
                _sendMessageCommand ??= new SendMessageCommand();
                return _sendMessageCommand;
            }
            set
            {
                _sendMessageCommand = value;
            }
        }
    }
}