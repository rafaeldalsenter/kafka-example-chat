using KafkaExampleChat.Messages;
using KafkaExampleChat.Producers;
using KafkaExampleChat.Topics;
using KafkaExampleChat.WpfApplication.ViewModels;
using System.Threading.Tasks;

namespace KafkaExampleChat.WpfApplication.Commands
{
    public abstract class BaseCommand<TMessage> where TMessage : Message
    {
        private readonly IProducer<TMessage> _producer;

        public BaseCommand(IProducer<TMessage> producer)
        {
            _producer = producer;
        }

        protected bool SendMessageToKafka(ChatViewModel viewModel, ITopic topic, TMessage message)
        {
            var task = Task.Run(async () =>
            {
                try
                {
                    await _producer.SendAsync(topic, message);

                    return true;
                }
                catch
                {
                    return false;
                }
            });

            task.Wait();

            return task.Result;
        }
    }
}