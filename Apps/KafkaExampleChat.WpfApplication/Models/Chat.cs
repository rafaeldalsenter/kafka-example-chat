using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;

namespace KafkaExampleChat.WpfApplication.Models
{
    public class Chat : INotifyPropertyChanged
    {
        private string _producerId;
        private string _statusBar;
        private string _message;
        private FlowDocument _chatWindow;

        public string ProducerId
        {
            get { return _producerId; }
            set
            {
                _producerId = value;
                OnPropertyChanged();
            }
        }

        public string StatusBar
        {
            get { return _statusBar; }
            set
            {
                _statusBar = value;
                OnPropertyChanged();
            }
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

        public FlowDocument ChatWindow
        {
            get { return _chatWindow; }
            set
            {
                _chatWindow = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged is null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}