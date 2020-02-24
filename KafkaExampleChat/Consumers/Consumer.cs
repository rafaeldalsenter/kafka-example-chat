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
        private IConsumer<Ignore, string> _consumer;
        private readonly IKafkaConfiguration _kafkaConfiguration;

        public Consumer(IKafkaConfiguration kafkaConfiguration)
        {
            _kafkaConfiguration = kafkaConfiguration;
            _consumer = new ConsumerBuilder<Ignore, string>(_kafkaConfiguration.GetConsumerConfiguration())
                .Build();
        }

        public async Task ExecuteAsync(string producerId, Action<ChatMessage> actionWriter, CancellationToken cancellationToken)
        {
            _consumer.Subscribe(new List<string> { "message-topic" });

            while (true)
            {
                var consumeResult = _consumer.Consume(cancellationToken);

                var message = JsonConvert.DeserializeObject<ChatMessage>(consumeResult.Value);

                if (!message.ProducerId.Equals(producerId))
                    actionWriter(message);

                _consumer.Commit(consumeResult);
            }
        }
    }
}