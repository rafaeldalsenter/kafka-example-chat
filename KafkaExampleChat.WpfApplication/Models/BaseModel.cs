using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KafkaExampleChat.WpfApplication.Models
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged is null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}