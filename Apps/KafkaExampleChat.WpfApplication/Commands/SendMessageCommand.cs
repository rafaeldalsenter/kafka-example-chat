using KafkaExampleChat.WpfApplication.Models;
using KafkaExampleChat.WpfApplication.ViewModels;
using System;
using System.Windows.Documents;
using System.Windows.Input;

namespace KafkaExampleChat.WpfApplication.Commands
{
    public class SendMessageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var viewModel = parameter as ChatViewModel;
            viewModel.ChatModel.StatusBar = "Enviando...";

            // Aqui enviar criar uma mensagem ao produtor

            // se retornar sucesso, escrever a mensagem na tela

            viewModel.ChatModel.StatusBar = "Enviado!";

            viewModel.ChatModel.AddMessage(new MessageModel
            {
                ProducerId = viewModel.ChatModel.ProducerId,
                Message = viewModel.ChatModel.Message
            });

            viewModel.ChatModel.Message = string.Empty;
        }
    }
}