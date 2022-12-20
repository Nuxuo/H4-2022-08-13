using Microsoft.AspNetCore.SignalR;

namespace H4_WebApi
{
    public class ChatHub : Hub
    {

        //                       ALL CHAT                          //
        public async Task SendMessage(string user, string message, bool sys)
            => await Clients.All.SendAsync("ReceiveMessage", user, message, sys);


        //                      PRIVATE CHAT                       //
        public async Task SendPrivateMessage(string targetUser, string user, string message, bool sys)
            => await Clients.User(targetUser).SendAsync("ReceivePrivateMessage" , user, message, sys);
            

        //                       GROUP CHAT                        //
        public async Task JoinGroup(string group)
            => await Groups.AddToGroupAsync(Context.ConnectionId, group);

        public async Task LeaveGroup(string group)
            => await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);

        public async Task SendGroupMessage(string group, string user, string message, bool sys)
            => await Clients.Group(group).SendAsync("ReceiveGroupMessage", user, message, sys);
    }
}