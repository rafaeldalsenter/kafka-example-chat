using Confluent.Kafka;

namespace KafkaExampleChat.Configurations
{
    public class KafkaConfiguration : IKafkaConfiguration
    {
        private readonly string _servers;
        private readonly string _clientId;
        private readonly BrokerAddressFamily _brokerAddressFamily;

        public KafkaConfiguration(string servers, string clientId, BrokerAddressFamily brokerAddressFamily)
        {
            _servers = servers;
            _clientId = clientId;
            _brokerAddressFamily = brokerAddressFamily;
        }

        public ConsumerConfig GetConsumerConfiguration()
            => new ConsumerConfig
            {
                BootstrapServers = _servers,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                GroupId = "default",
                ClientId = _clientId
            };

        public ProducerConfig GetProducerConfiguration()
            => new ProducerConfig(new ClientConfig()
            {
                BootstrapServers = _servers,
                ClientId = _clientId
            });
    }
}