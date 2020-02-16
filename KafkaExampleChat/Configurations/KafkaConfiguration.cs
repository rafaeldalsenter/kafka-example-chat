using Confluent.Kafka;
using KafkaExampleChat.Configurations.Dtos;

namespace KafkaExampleChat.Configurations
{
    public class KafkaConfiguration : IKafkaConfiguration
    {
        private readonly KafkaConfigurationDto _dto;

        public KafkaConfiguration(KafkaConfigurationDto dto)
        {
            _dto = dto;
        }

        public ProducerConfig GetProducerConfiguration()
            => new ProducerConfig(new ClientConfig()
            {
                BootstrapServers = _dto.Servers,
                BrokerAddressFamily = _dto.BrokerAddressFamily,
            });
    }
}