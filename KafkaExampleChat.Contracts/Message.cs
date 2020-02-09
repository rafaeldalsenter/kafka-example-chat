using System;

namespace KafkaExampleChat.Contracts
{
    public abstract class Message
    {
        public Guid Id { get; set; }
    }
}