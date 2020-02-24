using Confluent.Kafka;
using System;

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
                BrokerAddressFamily = _brokerAddressFamily,
                AutoOffsetReset = AutoOffsetReset.Latest,
                EnableAutoCommit = false,
                GroupId = Guid.NewGuid().ToString(),
                ClientId = _clientId
            };

        public ProducerConfig GetProducerConfiguration()
            => new ProducerConfig(new ClientConfig()
            {
                BootstrapServers = _servers,
                BrokerAddressFamily = _brokerAddressFamily,
                ClientId = _clientId
            });
    }
}