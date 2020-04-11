namespace KafkaExampleChat.Messages
{
    public class ActivityMessage : Message
    {
        public string ProducerId { get; set; }
        public bool IsWriting { get; set; }
    }
}