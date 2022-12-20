using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4_ChatApp.Services.Interfaces
{
    public interface IChatService
    {
        //                      CONNECTION                          //
        Task Connect();
        Task Disconnect();

        //                       METOHDS                          //

        Task JoinGroup(string group);
        Task LeaveGroup(string group);


        //                       CALL BACK                         //
        public void ReceiveMessage(Action<string, string, bool> GetMessageAndUser, string method);
    }
}
