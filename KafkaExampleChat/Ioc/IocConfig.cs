using KafkaExampleChat.Configurations;
using KafkaExampleChat.Consumers;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Producers;
using Unity;

namespace KafkaExampleChat.Ioc
{
    public class IocConfig
    {
        public static UnityContainer CreateContainer()
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IKafkaConfiguration, KafkaConfiguration>();
            unityContainer.RegisterType<IConsumer<ChatMessage>, Consumer>();
            unityContainer.RegisterType<IProducer<ChatMessage>, Producer>();

            return unityContainer;
        }
    }
}