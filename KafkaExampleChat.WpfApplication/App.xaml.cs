using KafkaExampleChat.Ioc;
using KafkaExampleChat.WpfApplication.Ioc;
using KafkaExampleChat.WpfApplication.Tasks;
using KafkaExampleChat.WpfApplication.ViewModels;
using KafkaExampleChat.WpfApplication.Views;
using System.Threading;
using System.Windows;
using Unity;

namespace KafkaExampleChat.WpfApplication
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityConfig().GetContainer;

            var receiveTask = container.Resolve<ReceiveMessageTask>();
            var viewModel = container.Resolve<ChatViewModel>();
            var window = container.Resolve<MainWindow>();

            receiveTask.ViewModel = viewModel;
            receiveTask.Execute(CancellationToken.None);

            window.DataContext = viewModel;
            window.Show();
        }
    }
}