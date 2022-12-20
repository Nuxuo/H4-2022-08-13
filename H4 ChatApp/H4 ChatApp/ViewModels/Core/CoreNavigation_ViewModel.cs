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
using System.Collections.ObjectModel;

namespace H4_ChatApp.ViewModels.Core
{
    public class CoreNavigation_ViewModel : INotifyPropertyChanged , IQueryAttributable
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

        private ObservableCollection<GroupModel> _GroupsList = new ObservableCollection<GroupModel>();
        public ObservableCollection<GroupModel> GroupsList
        {
            get => _GroupsList;
            set
            {
                _GroupsList = value;
                OnPropertyChanged(nameof(GroupsList));
            }
        }

        private ObservableCollection<PrivateModel> _PrivatesList = new ObservableCollection<PrivateModel>();
        public ObservableCollection<PrivateModel> PrivatesList
        {
            get => _PrivatesList;
            set
            {
                _PrivatesList = value;
                OnPropertyChanged(nameof(PrivatesList));
            }
        }

        public Command Navigate_ChatRoom_Command { get; set; }
        public Command Navigate_GroupPage_Command { get; set; }
        public Command Navigate_PrivatePage_Command { get; set; }
        public Command Navigate_MainPage_Command { get; set; }


        public WCF_ChatService.IChatService _wcf;

        public CoreNavigation_ViewModel()
        {
            Navigate_ChatRoom_Command = new Command(Navigate_ChatRoom);
            Navigate_GroupPage_Command = new Command(Navigate_GroupPage);
            Navigate_PrivatePage_Command = new Command(Navigate_PrivatePage);
            Navigate_MainPage_Command = new Command(Navigate_MainPage);

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _wcf = new WCF_ChatService.ChatServiceClient();

            Username = query["Username"] as string;
            UserId = Int32.Parse(query["UserId"] as string);

            GetGroupList();
            GetPrivateList();
        }

        private async void GetGroupList()
        {
            _GroupsList.Clear();
            List<WCF_ChatService.GroupModel> _list = await _wcf.GetGroupsContactsAsync(UserId);
            foreach (WCF_ChatService.GroupModel group in _list)
            {
                GroupsList.Add(new GroupModel { Id = group.Id, GroupName = group.GroupName });
            }
        }

        private async void GetPrivateList()
        {
            _PrivatesList.Clear();
            List<WCF_ChatService.PrivateModel> _list = await _wcf.GetPrivateContactsAsync(UserId);
            foreach (WCF_ChatService.PrivateModel privateContact in _list)
            {
                PrivatesList.Add(new PrivateModel { Id = privateContact.Id, Name = privateContact.Username });
            }
        }

        async void Navigate_ChatRoom()
        {
                var navigationParameter = new Dictionary<string, object>{{ "Username",  _Username}, { "UserId", UserId.ToString() } };
                await Shell.Current.GoToAsync($"ChatRoom", navigationParameter);
        }

        async void Navigate_GroupPage()
        {
                var navigationParameter = new Dictionary<string, object> { { "Username", Username }, { "UserId", UserId.ToString() } };
                await Shell.Current.GoToAsync($"GroupPage", navigationParameter);
        }

        async void Navigate_PrivatePage()
        {
                var navigationParameter = new Dictionary<string, object> { { "Username", Username }, { "UserId", UserId.ToString() } };
                await Shell.Current.GoToAsync($"PrivatePage", navigationParameter);     
        }
        async void Navigate_MainPage()
        {
            var navigationParameter = new Dictionary<string, object> { { "Username", Username }, { "UserId", UserId.ToString() } };
            await Shell.Current.GoToAsync($"MainPage", navigationParameter);
        }

    }
}
