using KafkaExampleChat.Ioc;
using KafkaExampleChat.WpfApplication.Commands;
using KafkaExampleChat.WpfApplication.Tasks;
using KafkaExampleChat.WpfApplication.ViewModels;
using KafkaExampleChat.WpfApplication.Views;
using System;
using Unity;

namespace KafkaExampleChat.WpfApplication.Ioc
{
    public class UnityConfig
    {
        private static readonly Lazy<UnityContainer> _unityContainerLazy = new Lazy<UnityContainer>(CreateContainer);

        public UnityContainer GetContainer => _unityContainerLazy.Value;

        private static UnityContainer CreateContainer()
        {
            var unityContainer = IocConfig.CreateContainer();

            unityContainer.RegisterType<ReceiveMessageTask>();
            unityContainer.RegisterType<SendMessageCommand>();
            unityContainer.RegisterType<SendActivityCommand>();
            unityContainer.RegisterType<MainWindow>();
            unityContainer.RegisterType<ChatViewModel>();

            return unityContainer;
        }
    }
}