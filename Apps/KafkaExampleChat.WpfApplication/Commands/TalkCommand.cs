using KafkaExampleChat.WpfApplication.ViewModels;
using System;
using System.Windows.Documents;
using System.Windows.Input;

namespace KafkaExampleChat.WpfApplication.Commands
{
    public class TalkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var viewModel = parameter as ChatViewModel;
            viewModel.Chat.ChatWindow ??= new FlowDocument();

            viewModel.Chat.StatusBar = "Enviando...";

            // Aqui enviar criar uma mensagem ao produtor

            // se retornar sucesso, escrever a mensagem na tela

            viewModel.Chat.StatusBar = "Enviado!";

            AddToFlowDocument(viewModel.Chat.ChatWindow, viewModel);
            viewModel.Chat.Message = string.Empty;
        }

        private string FormatMessage(ChatViewModel viewModel)
            => $"[{viewModel.Chat.ProducerId}] disse: {viewModel.Chat.Message}";

        private void AddToFlowDocument(FlowDocument flowDocument, ChatViewModel viewModel)
        {
            var paragraph = new Paragraph(new Run(FormatMessage(viewModel)));
            paragraph.Margin = new System.Windows.Thickness(0, 2, 0, 0);
            flowDocument.Blocks.Add(paragraph);
        }
    }
}