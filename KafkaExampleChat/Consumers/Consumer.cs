using Confluent.Kafka;
using KafkaExampleChat.Configurations;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Topic.Extensions;
using KafkaExampleChat.Topics;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace KafkaExampleChat.Consumers
{
    public class Consumer : IConsumer<ChatMessage>
    {
        private readonly IKafkaConfiguration _kafkaConfiguration;

        public Consumer(IKafkaConfiguration kafkaConfiguration)
        {
            _kafkaConfiguration = kafkaConfiguration;
        }

        public void Execute(ITopic topic, Action<ChatMessage> actionWriter, CancellationToken cancellationToken)
        {
            using (var consumer = new ConsumerBuilder<string, string>(_kafkaConfiguration.GetConsumerConfiguration()).Build())
            {
                consumer.Subscribe(topic.ToList());

                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumeResult = consumer.Consume();
                    if (consumeResult is null) continue;

                    var message = JsonConvert.DeserializeObject<ChatMessage>(consumeResult.Value);

                    actionWriter(message);

                    consumer.Commit(consumeResult);
                }
            }
        }
    }
}