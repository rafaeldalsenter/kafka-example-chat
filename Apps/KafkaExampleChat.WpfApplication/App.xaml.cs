using KafkaExampleChat.WpfApplication.ViewModels;
using KafkaExampleChat.WpfApplication.Views;
using System.Windows;

namespace KafkaExampleChat.WpfApplication
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow();
            var viewModel = new ChatViewModel();
            window.DataContext = viewModel;
            window.Show();
        }
    }
}