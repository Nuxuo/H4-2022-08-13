using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using H4_ChatApp.Models;
using H4_ChatApp.Services.Core;
using H4_ChatApp.Services.Interfaces;
using H4_ChatApp.ViewModels.Core;
//using static Android.Provider.Settings;

namespace H4_ChatApp.ViewModels
{
    public class ChatRoom_ViewModel : CoreChat_ViewModel , IQueryAttributable, INotifyPropertyChanged
    {

        public Command SendCommand { get; set; }

        public ChatRoom_ViewModel()
        {
            SendCommand = new Command(Send);
            ChatHistory();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Username = query["Username"] as string;
            UserId = Int32.Parse(query["UserId"] as string);
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(UserId));
            await BaseSetup();
        }

        private async Task BaseSetup()
        {
            await _chatService.Disconnect();
            await _chatService.Connect();
            _chatService.ReceiveMessage(GetMessage,"All");
            await _chatService.SendMessage(Username, Username + " has joined!", true);
        }

        private async void Send()
        {
            if (_chatService.IsMessageValid(Message)){
                await _chatService.SendMessage(Username, Message, false);
                await _wcf.AddAllChatMessageAsync(UserId, Message);
                Message = string.Empty;
            }
        }

        private async void ChatHistory()
        {
            List<WCF_ChatService.MessageModel> _list = await _wcf.GetAllChatMessagesAsync();
            foreach (WCF_ChatService.MessageModel message in _list)
            {
                bool _own = message.Username == Username ? true : false;
                AddMessage(message.Username, message.Message, _own, false);
            }
        }
    }

}