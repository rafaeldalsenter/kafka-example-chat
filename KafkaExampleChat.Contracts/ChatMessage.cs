using System;

namespace KafkaExampleChat.Contracts
{
    public class ChatMessage : Message
    {
        public Guid ProducerId { get; set; }
        public string Text { get; set; }
    }
}