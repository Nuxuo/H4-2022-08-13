using H4_ChatApp.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_ChatApp.Services.Core
{
    public class ChatService : IChatService
    {
        private readonly HubConnection _hubConnection;

        public ChatService()
        {
            _hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.101:5117/ChatHub").Build();
        }

        //                       CONNECTION                          //
        public async Task Connect()
            => await _hubConnection.StartAsync();  

        public async Task Disconnect()
            => await _hubConnection.StopAsync();

        //                       METOHDS                          //
            // PRIVATE
        public async Task SendPrivateMessage(string targetUser,string user, string message, bool isSystemMessage)
            => await _hubConnection.InvokeAsync("SendPrivateMessage", targetUser, user, message, isSystemMessage);


            // GROUP
        public async Task SendGroupMessage(string group, string username, string message, bool isSystemMessage)
            => await _hubConnection.InvokeAsync("SendGroupMessage", group, username, message, isSystemMessage);
        public async Task JoinGroup(string group)
            => await _hubConnection.InvokeAsync("JoinGroup", group);
        public async Task LeaveGroup(string group)
            => await _hubConnection.InvokeAsync("LeaveGroup", group);


            // ALL CHAT
        public async Task SendMessage(string username, string message, bool isSystemMessage)
            => await _hubConnection.InvokeAsync("SendMessage", username, message, isSystemMessage);  


        //                       CALL BACK                         //
        public void ReceiveMessage(Action<string, string, bool> GetMessageAndUser , string method)
        {
            if(method == "All")
                _hubConnection.On("ReceiveMessage", GetMessageAndUser);
            else if (method == "Group")
                _hubConnection.On("ReceiveGroupMessage", GetMessageAndUser);
            else if (method == "Private")
                _hubConnection.On("ReceivePrivateMessage", GetMessageAndUser);
        }


        //                       CHECK                            //
        public bool IsMessageValid(string message)
        {
            string msg;
            try
            {
                msg = message.ToString();
                if (msg.Length <= 0)
                {
                    return false;
                }
            }
            catch (Exception) { return false; }

            if (msg != null)
            {
                return true;
            }

            return false;
        }
    }
}
