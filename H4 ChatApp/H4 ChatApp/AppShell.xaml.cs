using Microsoft.Maui.Hosting;

namespace H4_ChatApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("ChatRoom", typeof(H4_ChatApp.Views.ChatRoom));
        Routing.RegisterRoute("GroupChatRoom", typeof(H4_ChatApp.Views.GroupChatRoom));
        Routing.RegisterRoute("PrivateChatRoom", typeof(H4_ChatApp.Views.PrivateChatRoom));
        Routing.RegisterRoute("MainPage", typeof(H4_ChatApp.Views.MainPage));
        Routing.RegisterRoute("GroupPage", typeof(H4_ChatApp.Views.GroupPage));
        Routing.RegisterRoute("PrivatePage", typeof(H4_ChatApp.Views.PrivatePage));
    }
}
