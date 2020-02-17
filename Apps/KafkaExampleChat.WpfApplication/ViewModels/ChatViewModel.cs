using KafkaExampleChat.WpfApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace KafkaExampleChat.WpfApplication.ViewModels
{
    public class ChatViewModel
    {
        private Chat _chat;
        private TalkCommand _talkCommand;

        public ChatViewModel()
        {
            _chat = new Chat();
        }

        public Chat Chat
        {
            get { return _chat; }
            set { _chat = value; TalkCommand.RaiseCanExecuteChanged(); }
        }

        public TalkCommand TalkCommand
        {
            get
            {
                _talkCommand ??= new TalkCommand();
                return _talkCommand;
            }
            set
            {
                _talkCommand = value;
            }
        }
    }
}