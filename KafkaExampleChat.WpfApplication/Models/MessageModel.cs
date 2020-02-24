namespace KafkaExampleChat.WpfApplication.Models
{
    public class MessageModel : BaseModel
    {
        private string _producerId;
        private string _message;

        public string ProducerId
        {
            get { return _producerId; }
            set
            {
                _producerId = value;
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
    }
}