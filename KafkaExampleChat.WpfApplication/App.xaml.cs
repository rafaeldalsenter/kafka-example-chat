using KafkaExampleChat.WpfApplication.Tasks;
using KafkaExampleChat.WpfApplication.ViewModels;
using KafkaExampleChat.WpfApplication.Views;
using System.Threading;
using System.Windows;

namespace KafkaExampleChat.WpfApplication
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var receiveTask = new ReceiveMessageTask();

            var window = new MainWindow();
            var viewModel = new ChatViewModel();
            window.DataContext = viewModel;
            receiveTask.ViewModel = viewModel;
            receiveTask.Execute(CancellationToken.None);
            window.Show();
        }
    }
}