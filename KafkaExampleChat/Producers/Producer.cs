using Confluent.Kafka;
using KafkaExampleChat.Configurations;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KafkaExampleChat.Producers
{
    public class Producer : IProducer<ChatMessage>
    {
        private IProducer<Null, string> _producer;

        public Producer(IKafkaConfiguration kafkaConfiguration)
        {
            _producer = new ProducerBuilder<Null, string>(kafkaConfiguration.GetProducerConfiguration())
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