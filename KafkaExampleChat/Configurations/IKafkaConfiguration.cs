using Confluent.Kafka;

namespace KafkaExampleChat.Configurations
{
    public interface IKafkaConfiguration
    {
        ProducerConfig GetProducerConfiguration();
    }
}