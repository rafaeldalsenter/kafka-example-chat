using KafkaExampleChat.WpfApplication.Commands;
using KafkaExampleChat.WpfApplication.Models;

namespace KafkaExampleChat.WpfApplication.ViewModels
{
    public class ChatViewModel
    {
        private ChatModel _chatModel;
        private SendMessageCommand _sendMessageCommand;

        public ChatViewModel()
        {
            _chatModel = new ChatModel();
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