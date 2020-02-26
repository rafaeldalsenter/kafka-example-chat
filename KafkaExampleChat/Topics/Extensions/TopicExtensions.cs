using KafkaExampleChat.Topics;
using System.Collections.Generic;

namespace KafkaExampleChat.Topic.Extensions
{
    public static class TopicExtensions
    {
        public static IEnumerable<string> ToList(this ITopic topic)
            => new List<string>
            {
                topic.GetName()
            };
    }
}