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
//using Android.Webkit;
using H4_ChatApp.Models;
using H4_ChatApp.Services.Core;
using H4_ChatApp.ViewModels.Core;
using H4_ChatApp.Services.Interfaces;
//using static Android.Provider.Settings;

namespace H4_ChatApp.ViewModels
{
    public class GroupChatRoom_ViewModel : CoreChat_ViewModel , IQueryAttributable, INotifyPropertyChanged
    {
        public Command SendCommand { get; set; }

        private string _Group;
        public string Group
        {
            get
            {
                return _Group;
            }
            set
            {
                _Group = value;
                OnPropertyChanged(nameof(Group));
            }
        }

        private int _GroupId;
        public int GroupId
        {
            get
            {
                return _GroupId;
            }
            set
            {
                _GroupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }

        public GroupChatRoom_ViewModel()
        {
            SendCommand = new Command(Send);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Username = query["Username"] as string;
            UserId = Int32.Parse(query["UserId"] as string);

            Group = query["Group"] as string;
            GroupId = Int32.Parse(query["GroupId"] as string);

            ChatHistory();
            await BaseSetup();
        }

        public async Task BaseSetup()
        {
            await _chatService.Connect();
            await _chatService.JoinGroup(Group);
            _chatService.ReceiveMessage(GetMessage,"Group");
            await _chatService.SendGroupMessage(Group, Username, Username + " has joined!", true);
        }

        private async void Send()
        {
            if (_chatService.IsMessageValid(Message)){
                await _chatService.SendGroupMessage(Group, Username, Message, false);
                await _wcf.AddGroupChatMessageAsync(UserId, GroupId, Message);
                Message = string.Empty;
            }
        }

        private async void ChatHistory()
        {
            List<WCF_ChatService.MessageModel> _list = await _wcf.GetGroupChatMessagesAsync(GroupId);
            foreach (WCF_ChatService.MessageModel message in _list)
            {
                bool _own = message.Id == UserId ? true : false;
                AddMessage(message.Username, message.Message, _own, false);
            }
        }
    }
}