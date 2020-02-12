namespace KafkaExampleChat.Topics
{
    public class MessageTopic : ITopic
    {
        public string GetName() => "message-topic";
    }
}