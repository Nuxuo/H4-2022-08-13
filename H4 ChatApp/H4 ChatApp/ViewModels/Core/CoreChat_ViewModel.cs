using H4_ChatApp.Views;
//using Java.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using H4_ChatApp.Models;
using H4_ChatApp.Services.Core;

namespace H4_ChatApp.ViewModels.Core
{
    public class CoreChat_ViewModel : INotifyPropertyChanged
    {
        //              PROPERTY EVENTS           //
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _Username;
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private int _UserId;
        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }


        private IEnumerable<MessageModel> _MessageList;
        public IEnumerable<MessageModel> MessageList
        {
            get => _MessageList;
            set
            {
                _MessageList = value;
                OnPropertyChanged(nameof(MessageList));
            }
        }

        public WCF_ChatService.IChatService _wcf;
        public readonly ChatService _chatService;

        public CoreChat_ViewModel()
        {
            _MessageList = new List<MessageModel>();
            _chatService = new ChatService();
            _wcf = new WCF_ChatService.ChatServiceClient();
        }

        protected void GetMessage(string userName, string message, bool sys)
        {
            bool _own = userName == Username ? true : false;
            AddMessage(userName, message, _own, sys);
        }

        protected void AddMessage(string userName, string message, bool isOwner, bool isSystem)
        {
            var tempList = MessageList.ToList();
            tempList.Add(new MessageModel { IsOwnerMessage = isOwner, Message = message, Username = userName, IsSystemMessage = isSystem });
            MessageList = new List<MessageModel>(tempList);
        }

        public async Task LeavePage()
        {
            await _chatService.SendMessage(Username, Username + " has left!", true);
            await _chatService.Disconnect();
        }

    }
}
