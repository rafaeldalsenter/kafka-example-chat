using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace KafkaExampleChat.WpfApplication.Models
{
    public class ChatModel : BaseModel
    {
        private IList<MessageModel> _messages;
        private string _statusBar;
        private FlowDocument _chatWindow;
        private string _message;
        private string _producerId;

        public ChatModel()
        {
            _producerId = Guid.NewGuid().ToString();
            _messages = new List<MessageModel>();
            _chatWindow = new FlowDocument();
        }

        public string ProducerId
        {
            get { return _producerId; }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public IList<MessageModel> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }

        public void AddMessage(MessageModel message)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                var paragraph = new Paragraph(new Run(FormatMessage(message)));
                paragraph.Margin = new System.Windows.Thickness(0, 2, 0, 0);
                _chatWindow.Blocks.Add(paragraph);

                OnPropertyChanged(nameof(ChatWindow));
            }));
        }

        private string FormatMessage(MessageModel message)
            => $"[{message.ProducerId}] disse: {message.Message}";

        public string StatusBar
        {
            get { return _statusBar; }
            set
            {
                _statusBar = value;
                OnPropertyChanged();
            }
        }

        public FlowDocument ChatWindow
        {
            get { return _chatWindow; }
            set
            {
                _chatWindow = value;
                OnPropertyChanged();
            }
        }
    }
}