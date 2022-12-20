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
using H4_ChatApp.Services.Interfaces;
using H4_ChatApp.ViewModels.Core;
//using static Android.Provider.Settings;

namespace H4_ChatApp.ViewModels
{
    public class GroupPage_ViewModel : CoreNavigation_ViewModel
    {

        private GroupModel _SelectedGroup;
        public GroupModel selectedGroup
        {
            get
            {
                return _SelectedGroup;
            }
            set
            {
                _SelectedGroup = value;
                OnPropertyChanged(nameof(selectedGroup));

                if (_SelectedGroup != null)
                {
                    Navigate_GroupChatRoom();
                }
            }
        }


        public GroupPage_ViewModel()
        {
            selectedGroup = null;
        }


        public async void Navigate_GroupChatRoom()
        {
            var navigationParameter = new Dictionary<string, object> { { "Username", Username }, { "UserId" , UserId.ToString() } ,{ "Group", selectedGroup.GroupName }, { "GroupId", selectedGroup.Id.ToString() } };
            await Shell.Current.GoToAsync($"GroupChatRoom", navigationParameter);
        }
    }
}