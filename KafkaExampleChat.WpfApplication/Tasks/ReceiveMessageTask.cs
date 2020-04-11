using KafkaExampleChat.Consumers;
using KafkaExampleChat.Messages;
using KafkaExampleChat.Topics;
using KafkaExampleChat.WpfApplication.Models;
using KafkaExampleChat.WpfApplication.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaExampleChat.WpfApplication.Tasks
{
    public class ReceiveMessageTask
    {
        private readonly IConsumer<ChatMessage> _consumerChat;
        private readonly IConsumer<ActivityMessage> _consumerActivity;

        public ChatViewModel ViewModel { get; set; }

        public ReceiveMessageTask(IConsumer<ChatMessage> consumerChat,
            IConsumer<ActivityMessage> consumerActivity)
        {
            _consumerChat = consumerChat;
            _consumerActivity = consumerActivity;
        }

        public void Execute(CancellationToken cancellationToken)
        {
            Task.Run(() =>
            {
                _consumerChat.Execute(new ChatMessageTopic(), EscreverChat, cancellationToken);
            });

            Task.Run(() =>
            {
                _consumerActivity.Execute(new ChatActivityTopic(), EscreverActivity, cancellationToken);
            });
        }

        private void EscreverActivity(ActivityMessage activityMessage)
        {
            if (activityMessage.ProducerId.Equals(ViewModel.ChatModel.ProducerId)) return;

            ViewModel.ChatModel.StatusBar = $"{activityMessage.ProducerId.Substring(0, 5)} está escrevendo...";
        }

        private void EscreverChat(ChatMessage chatMessage)
        {
            var messageModel = new MessageModel
            {
                ProducerId = chatMessage.ProducerId,
                Message = chatMessage.Text
            };

            ViewModel.ChatModel.AddMessage(messageModel);
        }
    }
}