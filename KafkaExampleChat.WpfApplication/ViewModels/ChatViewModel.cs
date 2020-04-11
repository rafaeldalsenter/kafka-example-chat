using KafkaExampleChat.WpfApplication.Commands;
using KafkaExampleChat.WpfApplication.Models;

namespace KafkaExampleChat.WpfApplication.ViewModels
{
    public class ChatViewModel
    {
        private ChatModel _chatModel;
        private SendMessageCommand _sendMessageCommand;
        private SendActivityCommand _sendActivityCommand;

        public ChatViewModel(SendMessageCommand sendMessageCommand,
            SendActivityCommand sendActivityCommand)
        {
            _chatModel = new ChatModel();
            _sendMessageCommand = sendMessageCommand;
            _sendActivityCommand = sendActivityCommand;
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

        public SendActivityCommand SendActivityCommand
        {
            get { return _sendActivityCommand; }
            set
            {
                _sendActivityCommand = value;
            }
        }
    }
}