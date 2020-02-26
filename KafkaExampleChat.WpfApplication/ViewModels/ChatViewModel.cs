using KafkaExampleChat.WpfApplication.Commands;
using KafkaExampleChat.WpfApplication.Models;

namespace KafkaExampleChat.WpfApplication.ViewModels
{
    public class ChatViewModel
    {
        private ChatModel _chatModel;
        private SendMessageCommand _sendMessageCommand;

        public ChatViewModel(SendMessageCommand sendMessageCommand)
        {
            _chatModel = new ChatModel();
            _sendMessageCommand = sendMessageCommand;
        }

        public ChatModel ChatModel
        {
            get { return _chatModel; }
            set
            {
                _chatModel = value;
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }

        public SendMessageCommand SendMessageCommand
        {
            get { return _sendMessageCommand; }
            set
            {
                _sendMessageCommand = value;
            }
        }
    }
}