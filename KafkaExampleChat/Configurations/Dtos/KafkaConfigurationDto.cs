using Confluent.Kafka;

namespace KafkaExampleChat.Configurations.Dtos
{
    public class KafkaConfigurationDto
    {
        public string Servers { get; set; }
        public BrokerAddressFamily? BrokerAddressFamily { get; set; }
    }
}