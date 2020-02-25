using Confluent.Kafka;
using System;

namespace KafkaExampleChat.Configurations
{
    public class KafkaConfiguration : IKafkaConfiguration
    {
        private readonly string _servers;

        public KafkaConfiguration(string servers)
        {
            _servers = servers;
        }

        public ConsumerConfig GetConsumerConfiguration()
            => new ConsumerConfig
            {
                BootstrapServers = _servers,
                AutoOffsetReset = AutoOffsetReset.Latest,
                GroupId = Guid.NewGuid().ToString()
            };

        public ProducerConfig GetProducerConfiguration()
            => new ProducerConfig(new ClientConfig()
            {
                BootstrapServers = _servers
            });
    }
}