using Confluent.Kafka;
using KafkaExampleChat.Configurations;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace KafkaExampleChat.Producers
{
    public class Producer : IProducer<ChatMessage>
    {
        private IProducer<Null, string> _producer;
        private readonly IKafkaConfiguration _kafkaConfiguration;

        public Producer(IKafkaConfiguration kafkaConfiguration)
        {
            _kafkaConfiguration = kafkaConfiguration;
            _producer = new ProducerBuilder<Null, string>(_kafkaConfiguration.GetProducerConfiguration())
                .Build();
        }

        public async Task SendAsync(ITopic topic, ChatMessage message)
        {
            var producerMessage = new Message<Null, string>();
            producerMessage.Value = JsonConvert.SerializeObject(message);

            await _producer.ProduceAsync(topic.GetName(), producerMessage);
        }
    }
}