namespace KafkaExampleChat.Topics
{
    public class ChatActivityTopic : ITopic
    {
        public string GetName() => "activity-topic";
    }
}