using System;

namespace KafkaExampleChat.Messages
{
    public class ChatMessage : Message
    {
        public Guid ProducerId { get; set; }
        public string Text { get; set; }
    }
}