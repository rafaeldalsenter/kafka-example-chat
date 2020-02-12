using System;

namespace KafkaExampleChat.Messages
{
    public abstract class Message
    {
        public Guid Id { get; set; }
    }
}