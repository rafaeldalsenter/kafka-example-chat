namespace KafkaExampleChat.Topics
{
    public class ChatMessageTopic : ITopic
    {
        public string GetName() => "message-topic";
    }
}