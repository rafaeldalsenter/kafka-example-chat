using Confluent.Kafka;
using KafkaExampleChat.Configurations;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaExampleChat.Consumers
{
    public class Consumer : IConsumer<ChatMessage>
    {
        private readonly IKafkaConfiguration _kafkaConfiguration;

        public Consumer(IKafkaConfiguration kafkaConfiguration)
        {
            _kafkaConfiguration = kafkaConfiguration;
        }

        public void Execute(string producerId, Action<ChatMessage> actionWriter, CancellationToken cancellationToken)
        {
            using (var consumer = new ConsumerBuilder<string, string>(_kafkaConfiguration.GetConsumerConfiguration()).Build())
            {
                consumer.Subscribe(new List<string> { "message-topic" });

                while (true)
                {
                    var consumeResult = consumer.Consume();

                    if (consumeResult is null) continue;

                    var message = JsonConvert.DeserializeObject<ChatMessage>(consumeResult.Value);

                    //if (!message.ProducerId.Equals(producerId))
                    actionWriter(message);

                    consumer.Commit(consumeResult);
                }
            }
        }
    }
}