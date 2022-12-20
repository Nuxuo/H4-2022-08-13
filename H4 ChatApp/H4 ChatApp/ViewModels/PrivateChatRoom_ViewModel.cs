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

namespace H4_ChatApp.ViewModels
{
    public class PrivateChatRoom_ViewModel : CoreChat_ViewModel, IQueryAttributable, INotifyPropertyChanged
    {

        public Command SendCommand { get; set; }

        private string _PrivateTarget;
        public string PrivateTarget
        {
            get
            {
                return _PrivateTarget;
            }
            set
            {
                _PrivateTarget = value;
                OnPropertyChanged(nameof(PrivateTarget));
            }
        }

        private int _PrivateContactId;
        public int PrivateContactId
        {
            get
            {
                return _PrivateContactId;
            }
            set
            {
                _PrivateContactId = value;
                OnPropertyChanged(nameof(PrivateContactId));
            }
        }


        public PrivateChatRoom_ViewModel()
        {
            SendCommand = new Command(Send);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Username = query["Username"] as string;
            UserId = Int32.Parse(query["UserId"] as string);

            PrivateTarget = query["PrivateTarget"] as string;
            PrivateContactId = Int32.Parse(query["PrivateContactId"] as string);

            ChatHistory();
            await BaseSetup();
        }

        public async Task BaseSetup()
        {
            await _chatService.Disconnect();
            await _chatService.Connect();
            _chatService.ReceiveMessage(GetMessage, "Private");
            await _chatService.SendPrivateMessage(PrivateTarget , Username, Username + " joined the private chat!", true);
            GetMessage(Username, "You joined a private chat with " + PrivateTarget + "!", true);
        }

        private async void Send()
        {
            if (_chatService.IsMessageValid(Message)){
                await _chatService.SendPrivateMessage(PrivateTarget, Username, Message, false);
                await _wcf.AddPrivateChatMessageAsync(UserId, PrivateContactId, Message);
                GetMessage(Username, Message, false);
                Message = string.Empty;
            }
        }

        private async void ChatHistory()
        {
            List<WCF_ChatService.MessageModel> _list = await _wcf.GetPrivateChatMessagesAsync(PrivateContactId);
            foreach (WCF_ChatService.MessageModel message in _list)
            {
                bool _own = message.Id == UserId ? true : false;
                AddMessage(message.Username, message.Message, _own, false);
            }
        }

    }

}