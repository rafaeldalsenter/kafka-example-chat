using System;

namespace KafkaExampleChat.Messages
{
    public class ChatMessage : Message
    {
        public string ProducerId { get; set; }
        public string Text { get; set; }
    }
}