using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows.Input;

namespace KafkaExampleChat.WpfApplication.ViewModels
{
    public class TalkCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var viewModel = parameter as ChatViewModel;
            viewModel.Chat.ChatWindow ??= new FlowDocument();
            AddToFlowDocument(viewModel.Chat.ChatWindow, viewModel.Chat.Message);
        }

        private void AddToFlowDocument(FlowDocument flowDocument, string message)
        {
            var paragraph = new Paragraph(new Run(message));
            flowDocument.Blocks.Add(paragraph);
        }
    }
}