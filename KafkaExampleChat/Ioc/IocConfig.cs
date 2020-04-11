using KafkaExampleChat.Configurations;
using KafkaExampleChat.Consumers;
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
            unityContainer.RegisterType(typeof(IConsumer<>), typeof(Consumer<>));
            unityContainer.RegisterType(typeof(IProducer<>), typeof(Producer<>));

            return unityContainer;
        }
    }
}