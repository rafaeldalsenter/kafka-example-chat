using Confluent.Kafka;

namespace KafkaExampleChat.Configurations
{
    public class KafkaConfiguration : IKafkaConfiguration
    {
        private readonly string _servers;
        private readonly BrokerAddressFamily _brokerAddressFamily;

        public KafkaConfiguration(string servers, BrokerAddressFamily brokerAddressFamily)
        {
            _servers = servers;
            _brokerAddressFamily = brokerAddressFamily;
        }

        public ProducerConfig GetProducerConfiguration()
            => new ProducerConfig(new ClientConfig()
            {
                BootstrapServers = _servers,
                BrokerAddressFamily = _brokerAddressFamily,
            });
    }
}